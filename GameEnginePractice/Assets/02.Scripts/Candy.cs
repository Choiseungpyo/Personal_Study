using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Candy : MonoBehaviour
{
    // ��ũ��Ʈ ����
    PlayerUIManager playerUIManager;

    private void Awake()
    {
        playerUIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<PlayerUIManager>();
    }

    // Candy ����
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

        // ����� ĵ�� UI ����
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
}
