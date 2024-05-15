using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{

    // ��ũ��Ʈ ����
    ExpUIManager expUIManager;
    Level level;
    private void Awake()
    {
        expUIManager = GameObject.Find("UIManager").GetComponent<ExpUIManager>();
        level = GetComponent<Level>();
    }

    float currnetExp = 0;
    float totalExp = 100;

    public void PlusExp(float value)
    {
        currnetExp += value;
        expUIManager.ChangeExpBarValue(currnetExp, totalExp);
        if(CheckIfTotalExpAndCurrentExpAreSame()) // ���� ����ġ�� �� ����ġ�� ���� ä���� ���
        {
            // ������ 
            level.IncreaseCurrentLevel(1);
            // ��� �ý��� ����

        }

    }

    public void ResetExp()
    {
        currnetExp = 0;
    }

    public float ReturnCurrentExp()
    {
        return currnetExp;
    }

    public void ChangeTotalExp(float value)
    {
        totalExp = value;
    }

    bool CheckIfTotalExpAndCurrentExpAreSame()
    {
        if (currnetExp == totalExp)
            return true;
        return false;
    }
}
