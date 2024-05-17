using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUIManager : MonoBehaviour
{
    public Canvas Exp_Canvas;
    public Slider Exp_Slid;

    private void Start()
    {
        ResetExpBar();
    }

    /// <summary>
    /// Exp Bar�� value ���� �����Ѵ�.
    /// </summary>
    public void ResetExpBar()
    {
        Exp_Slid.value = 0;
    }

    /// <summary>
    /// Exp Bar�� ���� �����Ѵ�. 
    /// </summary>
    /// <param name="currentExp">���� ����ġ</param>
    /// <param name="totalExp">�� ����ġ</param>
    public void ChangeExpBarValue(float currentExp, float totalExp)
    {
        Exp_Slid.value = currentExp / totalExp;
    }

    // ���߿� ����ġ�� �����ϰ� ���� �ִϸ��̼� �����ϱ� 

}
