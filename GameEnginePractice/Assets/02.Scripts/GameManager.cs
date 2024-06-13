using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameOver;

    GameOverUIManager gameOverUIManager;

    GameObject player;
    GameObject enemyManager;
    GameObject npcManager;

    private void Start()
    {
        gameOverUIManager = GetComponent<GameOverUIManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyManager = GameObject.Find("EnemyManager");
        npcManager = GameObject.Find("npcManager");
    }

    public void SetGameOverState(bool value)
    {
        gameOver = value;
    }

    public void GameOver()
    {
        player.SetActive(false);
        enemyManager.SetActive(false);
        npcManager.SetActive(false);

        gameOverUIManager.ActivateGameOverUI();
    }
}
