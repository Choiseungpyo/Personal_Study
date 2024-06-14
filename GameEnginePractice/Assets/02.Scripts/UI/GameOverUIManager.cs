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
    NPCManager npcManager;
    AudioSource audioSource;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        npcManager = GameObject.Find("NPCManager").GetComponent<NPCManager>();
        GameObject uiManager = GameObject.Find("UIManager");
        playerUIManager = uiManager.GetComponent<PlayerUIManager>();
        puzzleUIManager = uiManager.GetComponent<PuzzleUIManager>();
        timerUIManager = uiManager.GetComponent<TimerUIManager>();
        audioSource = GetComponent<AudioSource>();

        SetGameOverUIState(false);
    }

    public void ActivateGameOverUI()
    {
        // UI 
        playerUIManager.SetPlayerUICanvasState(false);
        timerUIManager.SetTimerUIState(false);
        puzzleUIManager.SetPuzzleUICanvasState(false);
        SetGameOverUIState(true);

        // 스크립트
        player.enabled = false;
        puzzleUIManager.StopAllCoroutines();
        puzzleUIManager.enabled = false;
        enemyManager.StopAllCoroutines();
        enemyManager.enabled = false;
        npcManager.StopAllCoroutines();
        npcManager.enabled = false;
        puzzleUIManager.StopAllCoroutines();

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
        GetCandyTxt[1].text = " X " + candyCnt.ToString();

        candyCnt = player.GetComponent<Candy>().ReturnCandyCnt("muffin");
        GetCandyTxt[2].text = " X " + candyCnt.ToString();


        // Lost
        for(int i=0; i<LostCandyTxt.Length; i++)
        {
            candyCnt = enemyManager.ReturnGetCandyCnt(i);
            LostCandyTxt[i].text = " X " + candyCnt.ToString();
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

    IEnumerator LoadScene(string name)
    {
        SetAudioClip("ButtonClick");
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(name);
    }

    void SetAudioClip(string name)
    {
        audioSource.clip = AudioManager.instance.ReturnAudioClip(name);
    }
}
