using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : Singleton<PlayerUIManager>, IEventListener
{
    [SerializeField] private Canvas PlayerUI_Canvas;
    [SerializeField] private GameObject[] Candy = new GameObject[3];
    [SerializeField] private Slider RunGauge_Slid;

    private bool currentCandyState = false;
    private Player player;
    private Candy playerCandy;
    private int[] candyCounts = new int[3];

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        GameEventDispatcher.AddListener(GameEventType.GameStarted, this);
        GameEventDispatcher.AddListener(GameEventType.PuzzleStarted, this);
        GameEventDispatcher.AddListener(GameEventType.PuzzleEnded, this);
        GameEventDispatcher.AddListener(GameEventType.GameOverStarted, this);
    }

    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        playerCandy = playerObj.GetComponent<Candy>();

        player.OnRunGaugeChanged += ChangeRunGauge;
        playerCandy.OnCandyCountChanged += ChangeCandyCntTxt;

        for (int i = 0; i < Candy.Length; i++)
            ChangeCandyObjState(i, false);

        InitRunGauge();
        playerCandy.NotifyAllCandyCountsChanged();
        player.NotifyRunGaugeChanged();
        SetPlayerUICanvasState(true);
    }

    protected override void OnDestroy()
    {
        if (player != null)
            player.OnRunGaugeChanged -= ChangeRunGauge;

        if (playerCandy != null)
            playerCandy.OnCandyCountChanged -= ChangeCandyCntTxt;

        GameEventDispatcher.RemoveListener(GameEventType.GameStarted, this);
        GameEventDispatcher.RemoveListener(GameEventType.PuzzleStarted, this);
        GameEventDispatcher.RemoveListener(GameEventType.PuzzleEnded, this);
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
            case GameEventType.PuzzleStarted:
                HandlePuzzleStarted();
                break;
            case GameEventType.PuzzleEnded:
                HandlePuzzleEnded();
                break;
            case GameEventType.GameOverStarted:
                HandleGameOverStarted();
                break;
        }
    }

    private void ChangeRunGauge(float value)
    {
        RunGauge_Slid.value = value;
    }

    private void InitRunGauge()
    {
        RunGauge_Slid.value = 1;
    }

    public void ClickCandyBasketBtn()
    {
        StartCoroutine(MakeCandyBasketEffct());
    }

    private void ChangeCandyCntTxt(CandyType type, int count)
    {
        int index = type.ToIndex();
        candyCounts[index] = count;
        Candy[index].transform.GetChild(0).GetComponent<TMP_Text>().text = count.ToString();
    }

    private void RefreshCandyCntTxt(int index)
    {
        Candy[index].transform.GetChild(0).GetComponent<TMP_Text>().text = candyCounts[index].ToString();
    }

    private void ChangeCandyObjState(int index, bool value)
    {
        Candy[index].SetActive(value);
    }

    private IEnumerator MakeCandyBasketEffct()
    {
        if (!CheckCurrentCandyState())
        {
            for (int i = 0; i < Candy.Length; i++)
            {
                ChangeCandyObjState(i, !currentCandyState);
                RefreshCandyCntTxt(i);
                yield return new WaitForSeconds(0.15f);
            }
        }
        else
        {
            for (int i = Candy.Length - 1; i >= 0; i--)
            {
                ChangeCandyObjState(i, !currentCandyState);
                RefreshCandyCntTxt(i);
                yield return new WaitForSeconds(0.15f);
            }
        }

        ChangeCheckCurrentCandyState(!currentCandyState);
    }

    private void ChangeCheckCurrentCandyState(bool value)
    {
        currentCandyState = value;
    }

    private bool CheckCurrentCandyState()
    {
        return currentCandyState;
    }

    public void SetPlayerUICanvasState(bool value)
    {
        if (PlayerUI_Canvas != null)
        {
            PlayerUI_Canvas.enabled = value;
            GraphicRaycaster raycaster = PlayerUI_Canvas.GetComponent<GraphicRaycaster>();
            if (raycaster != null)
                raycaster.enabled = value;
        }
    }

    private void HandleGameStarted()
    {
        SetPlayerUICanvasState(true);
    }

    private void HandlePuzzleStarted()
    {
        SetPlayerUICanvasState(false);
    }

    private void HandlePuzzleEnded()
    {
        SetPlayerUICanvasState(true);
    }

    private void HandleGameOverStarted()
    {
        SetPlayerUICanvasState(false);
    }
}
