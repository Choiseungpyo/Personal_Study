using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Canvas PlayerUI_Canvas;

    public GameObject[] Candy = new GameObject[3];

    // �޸��� ������ ����
    public Slider RunGauge_Slid;
    float runGaugeSpeed = 0.5f;

    // ���� �ٱ��� ����
    bool currentCandyState = false;

    Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        for (int i = 0; i < Candy.Length; i++)
            ChangeCandyObjState(i, false);
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

    public void ClickCandyBasketBtn()
    {
        StartCoroutine(MakeCandyBasketEffct());
    }

    public void ChangeCandyCntTxt(int index, string type)
    {
        Candy[index].transform.GetChild(0).GetComponent<TMP_Text>().text = player.candy.ReturnCandyCnt(type).ToString();
    }

    void ChangeCandyObjState(int index, bool value)
    {
        Candy[index].SetActive(value);
    }

    IEnumerator MakeCandyBasketEffct()
    {
        if (!CheckCurrentCandyState())
        {
            for (int i=0; i < Candy.Length; i++)
            {
                ChangeCandyObjState(i, !currentCandyState);
                
                ChangeCandyCntTxt(i, ReturnCandyType(i));
                yield return new WaitForSeconds(0.15f);
            }
        }
        else
        {
            for (int i = Candy.Length-1; i >= 0; i--)
            {
                ChangeCandyObjState(i, !currentCandyState);
                ChangeCandyCntTxt(i, ReturnCandyType(i));
                yield return new WaitForSeconds(0.15f);
            }
        }
            
        
        ChangeCheckCurrentCandyState(!currentCandyState);
    }

    void ChangeCheckCurrentCandyState(bool value)
    {
        currentCandyState = value;
    }

    bool CheckCurrentCandyState()
    {
        return currentCandyState ? true : false;
    }

    string ReturnCandyType(int randCandyType)
    {
        switch (randCandyType)
        {
            case 0:
                return "hard";
            case 1:
                return "lollipop";
            case 2:
                return "muffin";
            default:
                Debug.LogWarning(randCandyType);
                return "";
        }
    }
}
