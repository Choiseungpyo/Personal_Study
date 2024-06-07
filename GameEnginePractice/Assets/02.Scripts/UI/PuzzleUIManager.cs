using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PuzzleUIManager : MonoBehaviour
{
    /* [0] : -160, 160      [1] : 0, 160        [2] : 160, 160
     * [3] : -160, 0        [x] : 0, 0          [4] : 160, 0
     * [5] : -160, -160     [6] : 0, -160       [7] : 160, -160
     */

    // ����
    public Canvas PuzzleUICanvas;
    public GameObject EmptyPiece;
    public GameObject[] PuzzlePieces = new GameObject[9];

    // ����
    public GameObject[] Bats = new GameObject[2];
    
    // ���ѽð�
    public TMP_Text TimerTxt;

    // ĵ��
    public Image CandyToGiveImg;
    public Sprite[] CandysSpirte = new Sprite[3];
    public TMP_Text CandyCntTxt; 

    Vector3[] answerPos = new  Vector3[9];

    // ����
    Transform clickedPuzzlePiece;

    bool moveClickedPieceCoroutineState = false;
    int emptyPieceNum = 8;

    // ���� ����
    bool gameIsEnded = false;
    bool gameResult = false;

    // Ÿ�̸�
    float timer = 61;
    bool shuffleIsEnded = false;

    // ĵ�� 
    int candyCnt = 0;

    Candy candy;
    private void Awake()
    {
        candy = GetComponent<Candy>();
    }

    private void Start()
    {
        // ����
        InitBatPos();

        // ����
        InitAnswerPos();

        // ĵ��
        SetCandyToGive();
        SetCandyRandomCnt();
        SetCandyCntTxt();
    }

    private void Update()
    {
        SetTimerTxt();
    }

    // x���� 160 ���̳��ų� y���� 160 ���� ���� ��� 
    public void ClickPuzzlePiece()
    {
        Debug.Log("Click Puzzle Piece");

        if (clickedPuzzlePiece != null)
        {
            Debug.Log(clickedPuzzlePiece);
            return;
        }
           
        clickedPuzzlePiece = EventSystem.current.currentSelectedGameObject.transform;

        if (CheckPuzzleIfPieceIsAdjacent(clickedPuzzlePiece.localPosition, EmptyPiece.transform.localPosition))
            StartCoroutine(MoveClickedPiece());
        else
            clickedPuzzlePiece = null;
            
    }

    bool CheckPuzzleIfPieceIsAdjacent(Vector3 obj1, Vector3 obj2)
    {
        // ����ִ� ���� ������ ������ ���� ������  �̿��� ���� ��� 
        if (obj1.x == obj2.x)
        {
            if (Mathf.Abs(obj1.y - obj2.y) == 160)
                return true;
            return false;
        }
        if(obj1.y == obj2.y)
        {
            if (Mathf.Abs(obj1.x - obj2.x) == 160)
                return true;
            return false;
        }
 
        return false;
    }

    IEnumerator MoveClickedPiece()
    {
        Vector3 orinalClickedPuzzlePiecePos = clickedPuzzlePiece.localPosition;
        while (Vector3.Distance(clickedPuzzlePiece.localPosition, EmptyPiece.transform.localPosition) > 0)
        {
            clickedPuzzlePiece.localPosition = Vector3.MoveTowards(clickedPuzzlePiece.localPosition, EmptyPiece.transform.localPosition, 2.5f);
            yield return null;
        }
        ChangeEmptyPiecePos(orinalClickedPuzzlePiecePos);
        clickedPuzzlePiece = null;
    }

    IEnumerator MoveClickedFinalPiece()
    {
        Vector3 orinalClickedPuzzlePiecePos = PuzzlePieces[emptyPieceNum].transform.localPosition;
        while (Vector3.Distance(PuzzlePieces[emptyPieceNum].transform.localPosition, EmptyPiece.transform.localPosition) > 0)
        {
            PuzzlePieces[emptyPieceNum].transform.localPosition = Vector3.MoveTowards(PuzzlePieces[emptyPieceNum].transform.localPosition, EmptyPiece.transform.localPosition, 2.5f);
            yield return null;
        }
        ChangeEmptyPiecePos(orinalClickedPuzzlePiecePos);
    }


    IEnumerator MoveClickedPiece(int index)
    {
        moveClickedPieceCoroutineState = true;
        Vector3 orinalClickedPuzzlePiecePos = PuzzlePieces[index].transform.localPosition;

        while (Vector3.Distance(PuzzlePieces[index].transform.localPosition, EmptyPiece.transform.localPosition) > 0)
        {
            PuzzlePieces[index].transform.localPosition = Vector3.MoveTowards(PuzzlePieces[index].transform.localPosition, EmptyPiece.transform.localPosition, 5f);
            yield return null;
        }

        ChangeEmptyPiecePos(orinalClickedPuzzlePiecePos);
        moveClickedPieceCoroutineState = false;
    }

    void ChangeEmptyPiecePos(Vector3 pos)
    {
        EmptyPiece.transform.localPosition = pos;
    }

    void SetEmptyPiece()
    {
        EmptyPiece.transform.localPosition = PuzzlePieces[8].transform.localPosition;
        EmptyPiece.GetComponent<Image>().raycastTarget = false;
        EmptyPiece.GetComponent<Button>().interactable = false;
        EmptyPiece.gameObject.SetActive(false);
        SetFinalPiece(emptyPieceNum);
    }

    void SetFinalPiece(int index)
    {
        PuzzlePieces[index].transform.localPosition = new Vector3(470, 0);
    }

    void InitAnswerPos()
    {
        for (int i = 0; i < answerPos.Length; i++)
        {
            answerPos[i] = PuzzlePieces[i].transform.localPosition;
        }
    }

    bool CheckAnswerPos()
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

    IEnumerator ShufflePuzzlePiece()
    {
        List<int> adjacentObjectIndexStorage = new List<int>();
        int i;
        int randomIndex = Random.Range(0, adjacentObjectIndexStorage.Count);
        int previousIndex = 7;
        for (int repeatCnt = 0; repeatCnt < 25; repeatCnt++)
        {
            for (i = 0; i < PuzzlePieces.Length; i++)
            {
                if (!CheckPuzzleIfPieceIsAdjacent(PuzzlePieces[i].transform.localPosition, EmptyPiece.transform.localPosition))
                    continue;
                //Debug.Log("�̿��� �ִ� �ε��� : " + i);
                adjacentObjectIndexStorage.Add(i);
            }

            randomIndex = Random.Range(0, adjacentObjectIndexStorage.Count);

            while(previousIndex == adjacentObjectIndexStorage[randomIndex])
                randomIndex = Random.Range(0, adjacentObjectIndexStorage.Count);

            previousIndex = adjacentObjectIndexStorage[randomIndex];
            StartCoroutine(MoveClickedPiece(adjacentObjectIndexStorage[randomIndex]));

            yield return new WaitUntil(() => !moveClickedPieceCoroutineState);

            adjacentObjectIndexStorage.Clear();
        }
        SetShuffleIsEnded(true);
    }

    public void ClickFinalPuzzlePiece()
    {
        if(CheckAnswerPos())
        {
            if (!moveClickedPieceCoroutineState)
            {
                StartCoroutine(MoveClickedFinalPiece());
                SetGameIsEndedState(true);
                SetGameResult(true);
                // ���� ����
            }
                
        }
    }

    IEnumerator MoveBat(int index)
    {
        Vector3[] targetRot = new Vector3[2];

        targetRot[0] = new Vector3(0, 180 * index, 35);
        targetRot[1] = new Vector3(0, 180 * index, 5);
        
        while(!CheckIfGameIsEnded())
        {
            // ��ƾ 1
            while (Bats[index].transform.localEulerAngles.z < 35)
            {
                Bats[index].transform.localRotation = Quaternion.RotateTowards(Bats[index].transform.localRotation, Quaternion.Euler(targetRot[0]), 0.1f);
                yield return null;
            }
            // ��ƾ2
            while (Bats[index].transform.localEulerAngles.z > 5)
            {
                Bats[index].transform.localRotation = Quaternion.RotateTowards(Bats[index].transform.localRotation, Quaternion.Euler(targetRot[1]), 0.1f);
                yield return null;
            }
        }
       

    }

    void InitBatPos()
    {
        //�ʱ�ȭ
        Bats[0].transform.localEulerAngles = new Vector3(0, 0, 20);
        Bats[1].transform.localEulerAngles = new Vector3(0, 180, 20);
    }

    void SetShuffleIsEnded(bool value)
    {
        shuffleIsEnded = value;
    }

    bool ReturnShuffleIsEnded()
    {
        return shuffleIsEnded;
    }

    void SetTimerTxt()
    {
        if (!ReturnShuffleIsEnded())
            return;

        if (CheckIfGameIsEnded())
            return;

        if (timer < 0)
            return;

        timer -= Time.deltaTime;
        TimerTxt.text = ((int)timer).ToString();
        
        CheckIfTimerIsOver();
    }

    void InitTimerTxt()
    {
        TimerTxt.text = ((int)timer).ToString();
    }

    void CheckIfTimerIsOver()
    {
        if (timer > 0)
            return;

        SetGameIsEndedState(true);
        SetGameResult(false);
    }

    void ResetTimer()
    {
        timer = 61;
    }

    bool CheckIfGameIsEnded()
    {
        if (gameIsEnded)
            return true;
        else 
            return false;
    }

    void SetGameIsEndedState(bool value)
    {
        gameIsEnded = value;
    }

    void SetGameResult(bool value)
    {
        gameResult = value;
    }
    
    bool CheckGameResult()
    {
        if(gameResult)
            return true;
        return false;
    }

    public void SetPuzzleUICanvasState(bool value)
    {
        PuzzleUICanvas.gameObject.SetActive(value);
    }

    void GiveCandy()
    {
        if (!CheckIfGameIsEnded())
            return;

        if (CheckGameResult())
        {
            // ���� ����
        }
        else
        {
            // n�� �� â �ݱ�
        }
    }

    void SetCandyToGive()
    {

        string candyToGive = candy.ReturnRandomCandy();
        int candySpriteIndex = 0;

        switch(candyToGive)
        {
            case "hard":
                candySpriteIndex = 0;
                break;
            case "lollipop":
                candySpriteIndex = 1;
                break;
            case "muffin":
                candySpriteIndex = 2;
                break;
            default:
                candySpriteIndex = 0;
                Debug.LogWarning(candyToGive);
                break;
        }
        SetCandyImg(candySpriteIndex);
    }

    void SetCandyImg(int index)
    {
        CandyToGiveImg.sprite = CandysSpirte[index];
    }

    void SetCandyCntTxt()
    {
        CandyCntTxt.text = candyCnt.ToString();
    }

    void SetCandyRandomCnt()
    {
        int randNum = Random.Range(5, 10);
        candyCnt = randNum;
    }

    private void OnEnable()
    {
        // ���� Ÿ�̸� 

        // ���� Ŭ����
        SetGameIsEndedState(false);
        SetGameResult(false);

        // ����
        InitBatPos();
        for (int i = 0; i < Bats.Length; i++)
            StartCoroutine(MoveBat(i));


        // ����
        SetShuffleIsEnded(false);
        InitAnswerPos();
        SetEmptyPiece();
        StartCoroutine(ShufflePuzzlePiece());

        // �ð�
        ResetTimer();
        InitTimerTxt();

        // ĵ��
        SetCandyToGive();
        SetCandyRandomCnt();
        SetCandyCntTxt();
        
    }

    
}