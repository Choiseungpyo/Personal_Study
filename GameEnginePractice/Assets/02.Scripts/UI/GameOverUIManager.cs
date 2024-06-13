using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUIManager : MonoBehaviour
{
    public Canvas GameOverUICanvas;

    public TMP_Text[] GetCandyTxt = new TMP_Text[3];
    public TMP_Text[] LostCandyTxt = new TMP_Text[3];

    public GameObject Cat;

    float catTime = 0;

    PlayerUIManager playerUIManager;
    PuzzleUIManager puzzleUIManager;
    TimerUIManager timerUIManager;
    Player player;
    EnemyManager enemyManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        GameObject uiManager = GameObject.Find("UIManager");
        playerUIManager = uiManager.GetComponent<PlayerUIManager>();
        puzzleUIManager = uiManager.GetComponent<PuzzleUIManager>();
        timerUIManager = uiManager.GetComponent<TimerUIManager>();

        SetGameOverUIState(false);
    }

    public void ActivateGameOverUI()
    {
        playerUIManager.SetPlayerUICanvasState(false);
        puzzleUIManager.ClosePuzzleUI();
        timerUIManager.SetTimerUIState(false);
        SetGameOverUIState(true);
        SetCandyData();
        StartCoroutine(RotateCat());
    }

    void SetGameOverUIState(bool value)
    {
        GameOverUICanvas.gameObject.SetActive(value);
    }


    void SetCandyData()
    {
        int candyCnt = 0;

        // Get
        candyCnt = player.GetComponent<Candy>().ReturnCandyCnt("hard");
        GetCandyTxt[0].text = " X " + candyCnt.ToString();

        candyCnt = player.GetComponent<Candy>().ReturnCandyCnt("lollipop");
        GetCandyTxt[0].text = " X " + candyCnt.ToString();

        candyCnt = player.GetComponent<Candy>().ReturnCandyCnt("muffin");
        GetCandyTxt[0].text = " X " + candyCnt.ToString();


        // Lost
        for(int i=0; i<LostCandyTxt.Length; i++)
        {
            candyCnt = enemyManager.ReturnGetCandyCnt(i);
            LostCandyTxt[i].text = " X " + candyCnt.ToString();
        }
    }

    public void ClickReplayBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void ClickGoTitmeBtn()
    {
        SceneManager.LoadScene("Title");
    }

    IEnumerator RotateCat()
    {
        while(true)
        {
            if (Input.GetKey(KeyCode.Y))
                break;
            Cat.transform.localRotation = Quaternion.Euler(0, 0, catTime * 50);
            yield return null;
            catTime += Time.deltaTime;
        }
        
    }

}
