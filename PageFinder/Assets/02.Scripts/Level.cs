using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    int currentLevel = 0;

    // ��ũ��Ʈ ����
    LevelUIManager levelUIManager;
    private void Awake()
    {
        levelUIManager = GameObject.Find("UIManager").GetComponent<LevelUIManager>();
        IncreaseCurrentLevel(0);
    }

    /// <summary>
    /// ���� ������ �����Ѵ�. 
    /// </summary>
    /// <returns></returns>
    public int ReturnCurrentLevel()
    {
        return currentLevel;
    }

    /// <summary>
    /// ���� ������ ������Ų��.
    /// </summary>
    /// <param name="value">������ų ��</param>
    public void IncreaseCurrentLevel(int value)
    {
        currentLevel += value;
        levelUIManager.SetLevel_Txt(currentLevel);
    }


}
