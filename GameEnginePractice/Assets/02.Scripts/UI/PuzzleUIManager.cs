using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PuzzleUIManager : Singleton<PuzzleUIManager>, IEventListener
{
    /* [0] : -160, 160      [1] : 0, 160        [2] : 160, 160
     * [3] : -160, 0        [x] : 0, 0          [4] : 160, 0
     * [5] : -160, -160     [6] : 0, -160       [7] : 160, -160
     */

    // 퍼즐
    [SerializeField] private Canvas PuzzleUICanvas;
    [SerializeField] private GameObject EmptyPiece;
    [SerializeField] private GameObject[] PuzzlePieces = new GameObject[9];
    [SerializeField] private GameObject ClearObject;

    // 유령
    [SerializeField] private TMP_Text ClearTypeTxt; 
    [SerializeField] private GameObject Ghost;
    [SerializeField] private Sprite[] GhostSprite = new Sprite[2];

    // 박쥐
    [SerializeField] private GameObject[] Bats = new GameObject[2];
    
    // 제한시간
    [SerializeField] private TMP_Text TimerTxt;

    // 캔디
    [SerializeField] private Image CandyToGiveImg;
    [SerializeField] private Sprite[] CandysSpirte = new Sprite[3];
    [SerializeField] private TMP_Text CandyCntTxt; 

    private Vector3[] answerPos = new  Vector3[9];

    // 퍼즐
    private Transform clickedPuzzlePiece;

    private const float puzzleCellSize = 160f;
    private const float puzzleMoveSpeed = 800f;
    private const float puzzlePositionTolerance = 5f;

    private bool moveClickedPieceCoroutineState = false;
    private bool puzzlePieceButtonsBound = false;
    private int emptyPieceNum = 8;

    // 게임 관리
    private bool gameIsEnded = false;
    private bool gameResult = false;

    // 타이머
    private float timer = 30;
    private bool shuffleIsEnded = false;

    // 캔디 
    private int candyCnt = 0;
    private CandyType candyToGive = CandyType.Hard;

    private Candy candy;
    private Candy playerCandy;
    private Player player;
    private GameManager gameManager;
    private AudioSource audioSource;
    protected override void Awake()
    {
        base.Awake();
        if (!IsSingletonInstance())
            return;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        candy = GetComponent<Candy>();
        playerCandy = playerObj.GetComponent<Candy>();
        player = playerObj.GetComponent<Player>();
        gameManager = GameManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        BindPuzzlePieceButtons();
        SetPuzzleUICanvasState(false);
    }

    private void OnEnable()
    {
        GameEventDispatcher.AddListener(GameEventType.GameStarted, this);
        GameEventDispatcher.AddListener(GameEventType.GameOverStarted, this);
    }

    protected override void OnDestroy()
    {
        GameEventDispatcher.RemoveListener(GameEventType.GameStarted, this);
        GameEventDispatcher.RemoveListener(GameEventType.GameOverStarted, this);
        base.OnDestroy();
    }

    public void OnEvent(GameEventType eventType)
    {
        switch (eventType)
        {
            case GameEventType.GameStarted:
                HandleGameStarted();
                break;
            case GameEventType.GameOverStarted:
                StopPuzzleForGameOver();
                break;
        }
    }

    private void Update()
    {
        SetTimerTxt();
    }

    // x값이 160 차이나거나 y값이 160 차이 나는 경우 
    public void ClickPuzzlePiece()
    {
        TryMovePuzzlePiece(GetSelectedPuzzlePieceTransform());
    }

    public void ClickPuzzlePiece(int puzzlePieceIndex)
    {
        if (puzzlePieceIndex < 0 || puzzlePieceIndex >= PuzzlePieces.Length)
            return;

        if (PuzzlePieces[puzzlePieceIndex] == null)
            return;

        TryMovePuzzlePiece(PuzzlePieces[puzzlePieceIndex].transform);
    }

    private void TryMovePuzzlePiece(Transform puzzlePiece)
    {
        if (!ReturnShuffleIsEnded())
            return;

        if (CheckIfGameIsEnded())
            return;

        if (moveClickedPieceCoroutineState || clickedPuzzlePiece != null)
            return;

        if (puzzlePiece == null)
            return;

        clickedPuzzlePiece = puzzlePiece;
        PlayAudio("PuzzleClick");

        if (CheckPuzzleIfPieceIsAdjacent(clickedPuzzlePiece.localPosition, EmptyPiece.transform.localPosition))
            StartCoroutine(MoveClickedPiece());
        else
            clickedPuzzlePiece = null;
    }
    private bool CheckPuzzleIfPieceIsAdjacent(Vector3 obj1, Vector3 obj2)
    {
        float xDistance = Mathf.Abs(obj1.x - obj2.x);
        float yDistance = Mathf.Abs(obj1.y - obj2.y);

        bool sameColumn = yDistance <= puzzlePositionTolerance;
        bool sameRow = xDistance <= puzzlePositionTolerance;
        bool oneCellApartX = Mathf.Abs(xDistance - puzzleCellSize) <= puzzlePositionTolerance;
        bool oneCellApartY = Mathf.Abs(yDistance - puzzleCellSize) <= puzzlePositionTolerance;

        return (sameColumn && oneCellApartX) || (sameRow && oneCellApartY);
    }

    private void BindPuzzlePieceButtons()
    {
        if (puzzlePieceButtonsBound)
            return;

        puzzlePieceButtonsBound = true;

        for (int i = 0; i < PuzzlePieces.Length; i++)
        {
            if (i == emptyPieceNum || PuzzlePieces[i] == null)
                continue;

            Button button = PuzzlePieces[i].GetComponent<Button>();
            if (button == null)
                continue;

            int puzzlePieceIndex = i;
            button.onClick.AddListener(() => ClickPuzzlePiece(puzzlePieceIndex));
        }
    }
    private Transform GetSelectedPuzzlePieceTransform()
    {
        if (EventSystem.current == null || EventSystem.current.currentSelectedGameObject == null)
            return null;

        Transform selectedTransform = EventSystem.current.currentSelectedGameObject.transform;
        while (selectedTransform != null)
        {
            for (int i = 0; i < PuzzlePieces.Length; i++)
            {
                if (PuzzlePieces[i] != null && selectedTransform == PuzzlePieces[i].transform)
                    return selectedTransform;
            }

            selectedTransform = selectedTransform.parent;
        }

        return null;
    }
    private IEnumerator MoveClickedPiece()
    {
        moveClickedPieceCoroutineState = true;
        Vector3 originalClickedPuzzlePiecePos = clickedPuzzlePiece.localPosition;
        Vector3 targetPos = EmptyPiece.transform.localPosition;

        while (Vector3.Distance(clickedPuzzlePiece.localPosition, targetPos) > puzzlePositionTolerance)
        {
            clickedPuzzlePiece.localPosition = Vector3.MoveTowards(clickedPuzzlePiece.localPosition, targetPos, Time.deltaTime * puzzleMoveSpeed);
            yield return null;
        }

        clickedPuzzlePiece.localPosition = targetPos;
        ChangeEmptyPiecePos(originalClickedPuzzlePiecePos);
        clickedPuzzlePiece = null;
        moveClickedPieceCoroutineState = false;
    }
    private IEnumerator MoveClickedFinalPiece()
    {
        Vector3 originalClickedPuzzlePiecePos = PuzzlePieces[emptyPieceNum].transform.localPosition;
        Vector3 targetPos = EmptyPiece.transform.localPosition;

        while (Vector3.Distance(PuzzlePieces[emptyPieceNum].transform.localPosition, targetPos) > puzzlePositionTolerance)
        {
            PuzzlePieces[emptyPieceNum].transform.localPosition = Vector3.MoveTowards(PuzzlePieces[emptyPieceNum].transform.localPosition, targetPos, Time.deltaTime * puzzleMoveSpeed);
            yield return null;
        }

        PuzzlePieces[emptyPieceNum].transform.localPosition = targetPos;
        ChangeEmptyPiecePos(originalClickedPuzzlePiecePos);
        SetClearObject(true);
    }


    private IEnumerator MoveClickedPiece(int index)
    {
        moveClickedPieceCoroutineState = true;
        Vector3 originalClickedPuzzlePiecePos = PuzzlePieces[index].transform.localPosition;
        Vector3 targetPos = EmptyPiece.transform.localPosition;

        while (Vector3.Distance(PuzzlePieces[index].transform.localPosition, targetPos) > puzzlePositionTolerance)
        {
            PuzzlePieces[index].transform.localPosition = Vector3.MoveTowards(PuzzlePieces[index].transform.localPosition, targetPos, Time.deltaTime * puzzleMoveSpeed);
            yield return null;
        }

        PuzzlePieces[index].transform.localPosition = targetPos;
        ChangeEmptyPiecePos(originalClickedPuzzlePiecePos);
        moveClickedPieceCoroutineState = false;
    }

    private void ChangeEmptyPiecePos(Vector3 pos)
    {
        EmptyPiece.transform.localPosition = pos;
    }

    private void SetEmptyPiece()
    {
        EmptyPiece.transform.localPosition = PuzzlePieces[8].transform.localPosition;
        EmptyPiece.GetComponent<Image>().raycastTarget = false;
        EmptyPiece.GetComponent<Button>().interactable = false;
        EmptyPiece.gameObject.SetActive(false);
        SetFinalPiecePos(emptyPieceNum);
    }

    private void SetFinalPiecePos(int index)
    {
        PuzzlePieces[index].transform.localPosition = new Vector3(470, 0);
    }

    private void SetFinalPieceState(bool value)
    {
        PuzzlePieces[emptyPieceNum].SetActive(value);
    }

    private void InitAnswerPos()
    {
        for (int i = 0; i < answerPos.Length; i++)
        {
            answerPos[i] = PuzzlePieces[i].transform.localPosition;
        }
    }

    private bool CheckAnswerPos()
    {
        for(int i=0; i< answerPos.Length;i++)
        {
            if (i == emptyPieceNum)
                continue;

            if (answerPos[i] != PuzzlePieces[i].transform.localPosition)
                return false;
        }
        return true;
    }

    private IEnumerator ShufflePuzzlePiece()
    {
        List<int> adjacentObjectIndexStorage = new List<int>();
        int i;
        int randomIndex = Random.Range(0, adjacentObjectIndexStorage.Count);
        int previousIndex = 7;
        for (int repeatCnt = 0; repeatCnt < 10; repeatCnt++)
        {
            for (i = 0; i < PuzzlePieces.Length; i++)
            {
                if (!CheckPuzzleIfPieceIsAdjacent(PuzzlePieces[i].transform.localPosition, EmptyPiece.transform.localPosition))
                    continue;
                //Debug.Log("이웃해 있는 인덱스 : " + i);
                adjacentObjectIndexStorage.Add(i);
            }

            randomIndex = Random.Range(0, adjacentObjectIndexStorage.Count);

            while(previousIndex == adjacentObjectIndexStorage[randomIndex])
            {
                randomIndex = Random.Range(0, adjacentObjectIndexStorage.Count);
            }
                

            previousIndex = adjacentObjectIndexStorage[randomIndex];
            StartCoroutine(MoveClickedPiece(adjacentObjectIndexStorage[randomIndex]));

            yield return new WaitUntil(() => !moveClickedPieceCoroutineState);

            adjacentObjectIndexStorage.Clear();
        }
        SetShuffleIsEnded(true);
    }

    public void ClickFinalPuzzlePiece()
    {
        PlayAudio("PuzzleClick");
        if (CheckAnswerPos())
        {
            if (!moveClickedPieceCoroutineState)
            {
                StartCoroutine(MoveClickedFinalPiece());
                SetGameIsEndedState(true);
                
                SetGameResult(true);
                // 사탕 지급
            }     
        }
    }

    private IEnumerator MoveBat(int index)
    {
        Vector3[] targetRot = new Vector3[2];

        targetRot[0] = new Vector3(0, 180 * index, 35);
        targetRot[1] = new Vector3(0, 180 * index, 5);
        
        while(!CheckIfGameIsEnded())
        {
            // 루틴 1
            while (Bats[index].transform.localEulerAngles.z < 35)
            {
                Bats[index].transform.localRotation = Quaternion.RotateTowards(Bats[index].transform.localRotation, Quaternion.Euler(targetRot[0]), 0.1f);
                yield return null;

            }
            // 루틴2
            while (Bats[index].transform.localEulerAngles.z > 5)
            {
                Bats[index].transform.localRotation = Quaternion.RotateTowards(Bats[index].transform.localRotation, Quaternion.Euler(targetRot[1]), 0.1f);
                yield return null;

            }
        }
       

    }

    private void InitBatPos()
    {
        //초기화
        Bats[0].transform.localEulerAngles = new Vector3(0, 0, 20);
        Bats[1].transform.localEulerAngles = new Vector3(0, 180, 20);
    }

    private void SetShuffleIsEnded(bool value)
    {
        shuffleIsEnded = value;
    }

    private bool ReturnShuffleIsEnded()
    {
        return shuffleIsEnded;
    }

    private void SetTimerTxt()
    {
        if (!ReturnShuffleIsEnded())
            return;

        if (CheckIfGameIsEnded())
            return;

        if (!PuzzleUICanvas.enabled)
            return;

        if (timer < 0)
            return;

        timer -= Time.deltaTime;
        TimerTxt.text = ((int)timer).ToString();
        
        CheckIfTimerIsOver();
    }

    private void InitTimerTxt()
    {
        TimerTxt.text = ((int)timer).ToString();
    }

    private void CheckIfTimerIsOver()
    {
        if (timer > 0)
            return;

        SetGameIsEndedState(true);
        SetGameResult(false);
        SetClearObject(false);
        SetFinalPieceState(false);
    }

    private void ResetTimer()
    {
        timer = 30;
    }

    private bool CheckIfGameIsEnded()
    {
        if (gameIsEnded)
            return true;
        else 
            return false;
    }

    private void SetGameIsEndedState(bool value)
    {
        gameIsEnded = value;
    }

    private void SetGameResult(bool value)
    {
        gameResult = value;
    }
    
    public string ReturnGameResult()
    {
        if(gameResult)
            return "Success";
        return "Fail";
    }

    public void SetPuzzleUICanvasState(bool value)
    {
        if (PuzzleUICanvas == null)
            return;

        PuzzleUICanvas.enabled = value;
        GraphicRaycaster raycaster = PuzzleUICanvas.GetComponent<GraphicRaycaster>();
        if (raycaster != null)
            raycaster.enabled = value;
    }

    private void GiveCandy(bool value)
    {
        if (!value)
            return;

        EnsureCandyReferences();

        if (playerCandy == null)
            return;

        playerCandy.ChangeCandyCnt(candyToGive, candyCnt);
    }

    private void SetCandyToGive()
    {
        EnsureCandyReferences();

        Candy candySource = candy != null ? candy : playerCandy;
        if (candySource != null)
            candyToGive = candySource.ReturnRandomCandy();
        else
            candyToGive = Random.Range(0, 3).ToCandyType();

        SetCandyImg(candyToGive.ToIndex());
    }

    private void SetCandyImg(int index)
    {
        if (CandyToGiveImg == null)
            return;

        if (index < 0 || index >= CandysSpirte.Length)
            return;

        if (CandysSpirte[index] == null)
            return;

        CandyToGiveImg.sprite = CandysSpirte[index];
    }

    private void EnsureCandyReferences()
    {
        if (candy == null)
            candy = GetComponent<Candy>();

        if (playerCandy != null)
            return;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            playerCandy = playerObj.GetComponent<Candy>();
    }

    private void SetCandyCntTxt()
    {
        if (CandyCntTxt != null)
            CandyCntTxt.text = candyCnt.ToString();
    }

    private void SetCandyRandomCnt()
    {
        int randNum = Random.Range(5, 10);
        candyCnt = randNum;
    }


    private void SetGhostSprite(bool result)
    {
        if (result)
            Ghost.GetComponent<Image>().sprite = GhostSprite[0];
        else
            Ghost.GetComponent<Image>().sprite = GhostSprite[1];
    }
    
    private void SetClearTypeTxt(bool result)
    {
        if (result)
            ClearTypeTxt.text = "!Success!";
        else
            ClearTypeTxt.text = "!Fail!";
    }

    private void SetClearObject(bool result)
    {
        SetClearObjecState(true);
        SetGhostSprite(result);
        SetClearTypeTxt(result);
        
        GiveCandy(result);

        GameObject.Find("SpecialNPC").GetComponent<SpecialNPC>().ChangeState(NPCStateType.End);
        player.ChangeDidGetCandyState(false);

        Invoke("ClosePuzzleUI", 2f);
    }

    private void SetClearObjecState(bool value)
    {
        ClearObject.SetActive(value);
    }

    public void ActivatePuzzleUI()
    {
        if (gameManager == null)
            gameManager = GameManager.Instance;

        if (gameManager != null)
            gameManager.StartPuzzle();

        clickedPuzzlePiece = null;
        moveClickedPieceCoroutineState = false;
        SetPuzzleUICanvasState(true);
        // 실제 타이머 

        // 게임 클리어
        SetGameIsEndedState(false);
        SetGameResult(false);

        // 박쥐
        InitBatPos();
        for (int i = 0; i < Bats.Length; i++)
            StartCoroutine(MoveBat(i));


        // 퍼즐
        SetFinalPieceState(true);
        SetShuffleIsEnded(false);
        InitAnswerPos();
        SetEmptyPiece();
        StartCoroutine(ShufflePuzzlePiece());

        // 시간
        ResetTimer();
        InitTimerTxt();

        // 캔디
        SetCandyToGive();
        SetCandyRandomCnt();
        SetCandyCntTxt();

        // 클리어 시
        SetClearObjecState(false);
    }

    private void ClosePuzzleUI()
    {
        StopAllCoroutines();
        SetPuzzleUICanvasState(false);

        if (gameManager == null)
            gameManager = GameManager.Instance;

        if (gameManager != null && !gameManager.CheckGameState(GameState.GameOver))
            gameManager.EndPuzzle();
    }

    public void ForceClosePuzzleUI()
    {
        CancelInvoke();
        StopAllCoroutines();
        SetGameIsEndedState(true);
        SetClearObjecState(false);
        SetPuzzleUICanvasState(false);
    }

    public void StopPuzzleForGameOver()
    {
        CancelInvoke();
        StopAllCoroutines();
        SetGameIsEndedState(true);
        SetClearObjecState(false);
    }

    private void HandleGameStarted()
    {
        CancelInvoke();
        StopAllCoroutines();
        SetGameIsEndedState(false);
        SetClearObjecState(false);
        SetPuzzleUICanvasState(false);
    }
    private void PlayAudio(string name)
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            audioSource = GetComponentInParent<AudioSource>();

        if (audioSource == null)
            return;

        if (AudioManager.Instance == null)
            return;

        AudioClip clip = AudioManager.Instance.ReturnAudioClip(name);
        if (clip == null)
            return;

        audioSource.clip = clip;
        audioSource.Play();
    }

    public bool CheckIfCanvasIsActivated()
    {
        return PuzzleUICanvas != null && PuzzleUICanvas.enabled;
    }
}

