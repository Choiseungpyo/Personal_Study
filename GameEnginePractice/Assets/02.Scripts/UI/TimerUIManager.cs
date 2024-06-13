using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUIManager : MonoBehaviour
{
    public Canvas TimerUICanvas;
    public GameObject TimerBar;

    float   endTime = 5;
    float   currentTime = 0;
    float   timerBarRot = 0;


    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ResetData();
        SetTimerUIState(true);
    }

    private void Update()
    {
        SetTimerBar();
    }

    void SetTimerBar()
    {
        if (CheckEndTime())
            return;


        // 시간에 따라 시계방향 회전(0~-90 -> -90~-180 -> ... -270->0)
        TimerBar.transform.localRotation = Quaternion.Euler(0, 0, timerBarRot * (360 / endTime));
        timerBarRot += -Time.deltaTime;
        currentTime += Time.deltaTime;

        if (CheckEndTime()) // 끝났을 때 한번만 동작하도록 한번 더 호출
            gameManager.GameOver();
    }
    
    bool CheckEndTime()
    {
        if (currentTime > endTime)
            return true;
        return false;
    }

    public void SetTimerUIState(bool value)
    {
        TimerUICanvas.gameObject.SetActive(value);
    }

    void ResetData()
    {
        currentTime = 0;
        timerBarRot = 0;
        TimerBar.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
