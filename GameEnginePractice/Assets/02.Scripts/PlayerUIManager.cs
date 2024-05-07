using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Canvas PlayerUI_Canvas;

    public Slider RunGauge_Slid;
    float runGaugeSpeed = 0.5f;

    Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        ChangeRunGauge();
    }

    void ChangeRunGauge()
    {
        if (!player.CheckIfCurrentStateIsRun())
        {
            RunGauge_Slid.value -= Time.deltaTime * runGaugeSpeed;
        }
        else
        {
            RunGauge_Slid.value += Time.deltaTime * runGaugeSpeed;
        }
    }

    public bool CheckIfRunGaugeIsFull()
    {
        if (RunGauge_Slid.value == 1)
            return true;
        return false;
    }
}
