using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUIManager : MonoBehaviour
{
    public Canvas TimerUICanvas;
    public GameObject TimerBar;

    float   endTime = 180;
    float   currentTime = 0;
    float   timerBarRot = 0;

    bool firstSound = false;

    AudioSource audioSource;
    GameManager gameManager;

    private void Start()
    {
        firstSound = false;
        endTime = 180;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
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

        if (endTime - 1 <= currentTime && !firstSound)
        {
            firstSound = true;
            Debug.Log(currentTime);
            PlayAudio();
        }
            

        if (CheckEndTime()) // 끝났을 때 한번만 동작하도록
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

    void PlayAudio()
    {
        audioSource.clip = AudioManager.instance.ReturnAudioClip("Clock");
        audioSource.Play();
    }
}
