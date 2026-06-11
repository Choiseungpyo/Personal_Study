using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIManager : Singleton<GameOverUIManager>, IEventListener
{
    [SerializeField] private Canvas GameOverUICanvas;
    [SerializeField] private TMP_Text[] GetCandyTxt = new TMP_Text[3];
    [SerializeField] private TMP_Text[] LostCandyTxt = new TMP_Text[3];
    [SerializeField] private GameObject Cat;

    private float catTime = 0;
    private Player player;
    private EnemyManager enemyManager;
    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        GameEventDispatcher.AddListener(GameEventType.GameStarted, this);
        GameEventDispatcher.AddListener(GameEventType.GameOverStarted, this);
    }

    private void Start()
    {
        CacheReferences();
        audioSource = GetComponent<AudioSource>();
        SetGameOverUIState(false);
    }

    protected override void OnDestroy()
    {
        GameEventDispatcher.RemoveListener(GameEventType.GameStarted, this);
        GameEventDispatcher.RemoveListener(GameEventType.GameOverStarted, this);
        base.OnDestroy();
    }

    public void ActivateGameOverUI()
    {
        HandleGameOverStarted();
    }

    public void OnEvent(GameEventType eventType)
    {
        switch (eventType)
        {
            case GameEventType.GameStarted:
                HandleGameStarted();
                break;
            case GameEventType.GameOverStarted:
                HandleGameOverStarted();
                break;
        }
    }

    private void HandleGameOverStarted()
    {
        CacheReferences();
        StopAllCoroutines();
        catTime = 0;

        SetGameOverUIState(true);
        SetCandyData();
        StartCoroutine(RotateCat());
    }

    private void CacheReferences()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.GetComponent<Player>();
        }

        if (enemyManager == null)
            enemyManager = EnemyManager.Instance;
    }

    private void HandleGameStarted()
    {
        StopAllCoroutines();
        catTime = 0;
        SetGameOverUIState(false);
    }

    private void SetGameOverUIState(bool value)
    {
        if (GameOverUICanvas == null)
            return;

        GameOverUICanvas.transform.localScale = Vector3.one;
        GameOverUICanvas.enabled = value;
        GraphicRaycaster raycaster = GameOverUICanvas.GetComponent<GraphicRaycaster>();
        if (raycaster != null)
            raycaster.enabled = value;
    }

    private void SetCandyData()
    {
        if (player == null)
            return;

        Candy candy = player.GetComponent<Candy>();
        if (candy == null)
            return;

        if (GetCandyTxt.Length > 0 && GetCandyTxt[0] != null)
            GetCandyTxt[0].text = " X " + candy.ReturnCandyCnt(CandyType.Hard).ToString();

        if (GetCandyTxt.Length > 1 && GetCandyTxt[1] != null)
            GetCandyTxt[1].text = " X " + candy.ReturnCandyCnt(CandyType.Lollipop).ToString();

        if (GetCandyTxt.Length > 2 && GetCandyTxt[2] != null)
            GetCandyTxt[2].text = " X " + candy.ReturnCandyCnt(CandyType.Muffin).ToString();

        if (enemyManager == null)
            return;

        for (int i = 0; i < LostCandyTxt.Length; i++)
        {
            if (LostCandyTxt[i] != null)
                LostCandyTxt[i].text = " X " + enemyManager.ReturnGetCandyCnt(i).ToString();
        }
    }

    public void ClickReplayBtn()
    {
        StartCoroutine(LoadScene("Main"));
    }

    public void ClickGoTitleBtn()
    {
        StartCoroutine(LoadScene("Title"));
    }

    private IEnumerator RotateCat()
    {
        if (Cat == null)
            yield break;

        while (true)
        {
            if (Input.GetKey(KeyCode.Y))
                break;

            Cat.transform.localRotation = Quaternion.Euler(0, 0, catTime * 50);
            yield return null;
            catTime += Time.deltaTime;
        }
    }

    private IEnumerator LoadScene(string name)
    {
        SetAudioClip("ButtonClick");
        if (audioSource != null)
            audioSource.Play();

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(name);
    }

    private void SetAudioClip(string name)
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            return;

        if (AudioManager.Instance == null)
            return;

        audioSource.clip = AudioManager.Instance.ReturnAudioClip(name);
    }
}
