using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCUIManager : MonoBehaviour
{
    public Sprite[] CandySprites = new Sprite[3]; 
    public Image CandyImg;

    public void ChangeCandImg(string type)
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
}
