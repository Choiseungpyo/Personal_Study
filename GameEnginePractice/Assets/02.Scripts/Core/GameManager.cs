using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool gameOver;
    private GameState currentState = GameState.Explore;

    private Player player;
    private EnemyManager enemyManager;
    private NPCManager npcManager;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        CacheReferences();
        StartGame();
    }

    public void SetGameOverState(bool value)
    {
        gameOver = value;
    }

    public void GameOver()
    {
        if (gameOver)
            return;

        bool value = false;
        SetGameOverState(true);
        ChangeGameState(GameState.GameOver);
        CacheReferences();

        if (player != null)
            player.enabled = value;

        if (enemyManager != null)
            enemyManager.enabled = value;

        if (npcManager != null)
            npcManager.enabled = value;

        if (AudioManager.Instance != null)
            AudioManager.Instance.SetAudioClip("GameOverBGM");

        GameEventDispatcher.RaiseGameOverStarted();
    }

    public void StartGame()
    {
        SetGameOverState(false);
        ChangeGameState(GameState.Explore);
        GameEventDispatcher.RaiseGameStarted();
    }

    public void StartPuzzle()
    {
        if (gameOver)
            return;

        ChangeGameState(GameState.Puzzle);
        GameEventDispatcher.RaisePuzzleStarted();
    }

    public void EndPuzzle()
    {
        if (gameOver)
            return;

        ChangeGameState(GameState.Explore);
        GameEventDispatcher.RaisePuzzleEnded();
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

        if (npcManager == null)
            npcManager = NPCManager.Instance;

    }

    public void ChangeGameState(GameState value)
    {
        currentState = value;
    }

    public GameState ReturnGameState()
    {
        return currentState;
    }

    public bool CheckGameState(GameState value)
    {
        return currentState == value;
    }

    public bool CanEnemiesMove()
    {
        return currentState == GameState.Explore;
    }

    public bool CanSpawnEnemy()
    {
        return currentState == GameState.Explore;
    }
}
