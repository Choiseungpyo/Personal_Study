using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    /// <summary>
    /// ������ ������ �����Ѵ�.
    /// </summary>
    /// <param name="color">������ ����</param>
    public void ChangeColor(Color color)
    {
        //Debug.Log("���� �� ����");
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
