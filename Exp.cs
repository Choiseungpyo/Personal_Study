using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{

    // 스크립트 관련
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
        if(CheckIfTotalExpAndCurrentExpAreSame()) // 현재 경험치가 총 경험치를 전부 채웠을 경우
        {
            // 레벨업 
            level.IncreaseCurrentLevel(1);
            // 기억 시스템 동작

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
