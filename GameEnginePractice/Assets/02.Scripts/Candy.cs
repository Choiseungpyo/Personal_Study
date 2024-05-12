using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    // Candy ฐüทร
    Dictionary<string, int> candy = new Dictionary<string, int>()
    {
        { "hard", 0},
        { "lollipop", 0},
        { "muffin", 0}
    };

    public void ChangeCandy(string type, int value)
    {
        switch(type)
        {
            case "hard":
                candy["hard"] += value;
                break;
            case "lollipop":
                candy["lollipop"] += value;
                break;
            case "muffin":
                candy["muffin"] += value;
                break;
            default:
                Debug.LogWarning(type + " - " + value);
                break;
        }
        Debug.Log(type + " ++");
        Debug.Log(candy["hard"]);
        Debug.Log(candy["lollipop"]);
        Debug.Log(candy["muffin"]);
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
