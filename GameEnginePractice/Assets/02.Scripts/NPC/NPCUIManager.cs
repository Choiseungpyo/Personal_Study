using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCUIManager : MonoBehaviour
{
    public Sprite[] CandySprites = new Sprite[3]; 
    public Image CandyImg;
    public TMP_Text CandyCntTxt;

    void ChangeCandImg(string type)
    {
        switch (type)
        {
            case "hard":
                CandyImg.sprite = CandySprites[0];
                break;
            case "lollipop":
                CandyImg.sprite = CandySprites[1];
                break;
            case "muffin":
                CandyImg.sprite = CandySprites[2];
                break;
            default:
                Debug.LogWarning(type);
                break;
        }
    }

    void ChangeCandyCntTxt(int cnt)
    {
        CandyCntTxt.text = "X " + cnt.ToString();
    }


    public void SetCandyData(string type, int cnt)
    {
        ChangeCandImg(type);
        ChangeCandyCntTxt(cnt);
    }
}
