using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCUIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] CandySprites = new Sprite[3]; 
    [SerializeField] private Image CandyImg;
    [SerializeField] private TMP_Text CandyCntTxt;

    private void ChangeCandImg(CandyType type)
    {
        CandyImg.sprite = CandySprites[type.ToIndex()];
    }

    private void ChangeCandyCntTxt(int cnt)
    {
        CandyCntTxt.text = "X " + cnt.ToString();
    }


    public void SetCandyData(CandyType type, int cnt)
    {
        ChangeCandImg(type);
        ChangeCandyCntTxt(cnt);
    }
}
