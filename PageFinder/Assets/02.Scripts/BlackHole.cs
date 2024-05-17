using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    /// <summary>
    /// 현재 상태를 변경한다. 
    /// </summary>
    /// <param name="value">변경할 활성화 상태 값</param>
    public void SetActiveState(bool value)
    {
        gameObject.SetActive(value);
    }
}
