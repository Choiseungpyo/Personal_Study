using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    /// <summary>
    /// ���� ���¸� �����Ѵ�. 
    /// </summary>
    /// <param name="value">������ Ȱ��ȭ ���� ��</param>
    public void SetActiveState(bool value)
    {
        gameObject.SetActive(value);
    }
}
