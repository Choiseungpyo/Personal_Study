using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Candy : MonoBehaviour
{
    // 스크립트 관련
    PlayerUIManager playerUIManager;

    private void Awake()
    {
        playerUIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<PlayerUIManager>();
    }

    private void Start()
    {
        // 캔디 개수 리셋
        ResetCandyCnt();
    }

    // Candy 관련
    Dictionary<string, int> candy = new Dictionary<string, int>()
    {
        { "hard", 0},
        { "lollipop", 0},
        { "muffin", 0}
    };

    public void ChangeCandyCnt(string type, int Candycnt)
    {
        int index = 0;
        switch(type)
        {
            case "hard":
                candy["hard"] += Candycnt;
                index = 0;
                break;
            case "lollipop":
                candy["lollipop"] += Candycnt;
                index = 1;
                break;
            case "muffin":
                candy["muffin"] += Candycnt;
                index = 2;
                break;
            default:
                Debug.LogWarning(type + " - " + Candycnt);
                index = 0;
                break;
        }

        // 변경된 캔디 UI 변경
        playerUIManager.ChangeCandyCntTxt(index, type);

        //Debug.Log(type + " ++");
        //Debug.Log(candy["hard"]);
        //Debug.Log(candy["lollipop"]);
        //Debug.Log(candy["muffin"]);//
        //Debug.Log(candy["muffin"]);//
    }


    public int ReturnCandyCnt(string type)
    {
        switch (type)
        {
            case "hard":
                return candy["hard"];
            case "lollipop":
                return candy["lollipop"];
            case "muffin":
                return candy["muffin"];
            default:
                Debug.LogWarning(type);
                return 0;
        }
    }

    public string ReturnRandomCandy()
    {
        int randCandyType =  Random.Range(0, 3); // 0 ~ 2
        switch(randCandyType)
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

    void ResetCandyCnt()
    {
        candy["hard"] = 0;
        candy["lollipop"] = 0;
        candy["muffin"] = 0;
    }
}
