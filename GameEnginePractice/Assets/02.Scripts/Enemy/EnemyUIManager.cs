using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : MonoBehaviour
{
    public Image CandyImg;
    public Sprite[] CandySprite = new Sprite[3];

    private void Start()
    {
        SetCandyImg();
    }

    void SetCandyImg()
    {
        string candyName ="";
        if(gameObject.name.Equals("Zombie"))
            candyName = GetComponent<Enemy>().ReturnCandyNameToTake();
        else if (gameObject.name.Equals("Pierrot"))
            candyName = GetComponent<Pierrot>().ReturnCandyNameToTake();
        else if (gameObject.name.Equals("Chainsaw"))
            candyName = GetComponent<Chainsaw>().ReturnCandyNameToTake();


        switch (candyName)
        {
            case "hard":
                CandyImg.sprite = CandySprite[0];
                break;
            case "lollipop":
                CandyImg.sprite = CandySprite[1];
                break;
            case "muffin":
                CandyImg.sprite = CandySprite[2];
                break;
            default:
                Debug.LogWarning("잘못된 candyName 받음");
                break;
        }
    }
}
