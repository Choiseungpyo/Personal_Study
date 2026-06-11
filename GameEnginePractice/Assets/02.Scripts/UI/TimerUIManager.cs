using UnityEngine;
using UnityEngine.UI;

public class TimerUIManager : Singleton<TimerUIManager>, IEventListener
{
    [SerializeField] private Canvas TimerUICanvas;
    [SerializeField] private GameObject TimerBar;

    [SerializeField] private float endTime = 120;
    private float elapsedTime = 0;
    private bool firstSound = false;
    private bool gameOverTriggered = false;
    private AudioSource audioSource;
    private GameManager gameManager;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        firstSound = false;
        gameManager = GameManager.Instance;
        audioSource = GetComponent<AudioSource>();
        ResetData();
        SetTimerUIState(true);
    }

    private void OnEnable()
    {
        GameEventDispatcher.AddListener(GameEventType.GameStarted, this);
        GameEventDispatcher.AddListener(GameEventType.PuzzleStarted, this);
        GameEventDispatcher.AddListener(GameEventType.PuzzleEnded, this);
        GameEventDispatcher.AddListener(GameEventType.GameOverStarted, this);
    }

    protected override void OnDestroy()
    {
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

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (gameOverTriggered)
            return;

        if (endTime <= 0f)
        {
            TriggerGameOver();
            return;
        }

        elapsedTime = Mathf.Min(elapsedTime + Time.deltaTime, endTime);

        if (TimerBar != null)
        {
            float progress = elapsedTime / endTime;
            TimerBar.transform.localRotation = Quaternion.Euler(0, 0, -360f * progress);
        }

        if (endTime - elapsedTime <= 1f && !firstSound)
        {
            firstSound = true;
            PlayAudio();
        }

        if (CheckEndTime())
            TriggerGameOver();
    }

    private void TriggerGameOver()
    {
        if (gameOverTriggered)
            return;

        gameOverTriggered = true;

        if (gameManager == null)
            gameManager = GameManager.Instance;

        if (gameManager != null)
            gameManager.GameOver();
    }

    private bool CheckEndTime()
    {
        return elapsedTime >= endTime;
    }

    public void SetTimerUIState(bool value)
    {
        if (TimerUICanvas != null)
        {
            TimerUICanvas.enabled = value;
            GraphicRaycaster raycaster = TimerUICanvas.GetComponent<GraphicRaycaster>();
            if (raycaster != null)
                raycaster.enabled = false;
        }
    }

    private void HandleGameStarted()
    {
        ResetData();
        SetTimerUIState(true);
    }

    private void HandlePuzzleStarted()
    {
        SetTimerUIState(true);
    }

    private void HandlePuzzleEnded()
    {
        SetTimerUIState(true);
    }

    private void HandleGameOverStarted()
    {
        gameOverTriggered = true;
        SetTimerUIState(false);
    }

    private void ResetData()
    {
        elapsedTime = 0;
        gameOverTriggered = false;

        if (TimerBar != null)
            TimerBar.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    private void PlayAudio()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
            return;

        if (AudioManager.Instance == null)
            return;

        audioSource.clip = AudioManager.Instance.ReturnAudioClip("Clock");
        audioSource.Play();
    }
}
