using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUIManager : MonoBehaviour
{
    public GameObject TimerBar;

    float   endTime = 60f;
    float   currentTime = 0;
    float   timerBarRot = 0;


    private void Update()
    {
        SetTimerBar();
    }

    void SetTimerBar()
    {
        if (CheckEndTime())
            return;

        // 시간에 따라 시계방향 회전(0~-90 -> -90~-180 -> ... -270->0)
        TimerBar.transform.localRotation = Quaternion.Euler(0, 0, timerBarRot);
        timerBarRot += -Time.deltaTime;
        currentTime += Time.deltaTime;
        //Debug.Log(currentTime);
    }
    
    bool CheckEndTime()
    {
        if (currentTime <= -360)
            return true;
        return false;
    }
}
