using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameOver;

    GameOverUIManager gameOverUIManager;

    Player player;
    EnemyManager enemyManager;
    NPCManager npcManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        npcManager = GameObject.Find("NPCManager").GetComponent<NPCManager>();
        gameOverUIManager = GameObject.Find("UIManager").GetComponent<GameOverUIManager>();
    }

    public void SetGameOverState(bool value)
    {
        gameOver = value;
    }

    public void GameOver()
    {
        bool value = false;
        player.enabled = value;
        enemyManager.enabled = value;
        npcManager.enabled = value;
        AudioManager.instance.SetAudioClip("GameOverBGM");
        gameOverUIManager.ActivateGameOverUI();
    }
}
