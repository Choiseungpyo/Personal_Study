using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUIManager : MonoBehaviour
{
    public GameObject TimerBar;

    float   endTime = 60f;
    float   currentTime = 0;
    int     timerSpeed = 10;


    private void Update()
    {
        SetTimerBar();
    }

    void SetTimerBar()
    {
        if (CheckEndTime())
            return;

        // �ð��� ���� �ð���� ȸ��(0~-90 -> -90~-180 -> ... -270->0)
        TimerBar.transform.localRotation = Quaternion.Euler(0, 0, currentTime);
        currentTime += -Time.deltaTime * timerSpeed;
        //Debug.Log(currentTime);
    }
    
    bool CheckEndTime()
    {
        if (currentTime <= -360)
            return true;
        return false;
    }
}
