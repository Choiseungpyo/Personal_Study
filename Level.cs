using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int currentLevel = 0;

    public int ReturnCurrentLevel()
    {
        return currentLevel;
    }

    public void IncreaseCurrentLevel(int value)
    {
        currentLevel += value;
    }


}
