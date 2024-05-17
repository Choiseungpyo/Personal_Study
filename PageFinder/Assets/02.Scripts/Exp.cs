using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{

    // ��ũ��Ʈ ����
    ExpUIManager expUIManager;
    ReinforceUIManager reinforceUIManager;
    Level level;

    float currentExp = 0;
    float totalExp = 100;

    private void Awake()
    {
        GameObject uiManager = GameObject.Find("UIManager");
        expUIManager = uiManager.GetComponent<ExpUIManager>();
        reinforceUIManager = uiManager.GetComponent<ReinforceUIManager>();
        level = GetComponent<Level>();
    }

   
    /// <summary>
    /// ����ġ�� ������Ų��.
    /// </summary>
    /// <param name="value">����ġ�� ������Ų��.</param>
    public void IncreaseExp(float value)
    {
        currentExp += value;

        expUIManager.ChangeExpBarValue(currentExp, totalExp);
        if(CheckIfTotalExpAndCurrentExpAreSame()) // ���� ����ġ�� �� ����ġ�� ���� ä���� ���(= �������� ���)
        {
            Debug.Log("LevelUp");
            
            Debug.Log("Exp Reset : " + currentExp);
            reinforceUIManager.StartCoroutine(reinforceUIManager.ActivateReinforceUI()); // ��� �ý��� UI ����
        }

    }

    /// <summary>
    /// ����ġ�� ���� 0���� �����Ѵ�. 
    /// </summary>
    public void ResetExp()
    {
        currentExp = 0;
    }

    /// <summary>
    /// ���� ����ġ�� �����Ѵ�.
    /// </summary>
    /// <returns>���� ����ġ</returns>
    public float ReturnCurrentExp()
    {
        return currentExp;
    }

    /// <summary>
    /// �� ����ġ�� �����Ѵ�.
    /// </summary>
    /// <param name="value">������ �� ����ġ ��</param>
    public void ChangeTotalExp(float value)
    {
        totalExp = value;
    }

    /// <summary>
    /// �� ����ġ�� ���� ����ġ�� ������ üũ�Ѵ�.
    /// </summary>
    /// <returns>���� ��� true</returns>
    bool CheckIfTotalExpAndCurrentExpAreSame() // �������� ���
    {
        if (currentExp == totalExp)
            return true;
        return false;
    }
}
