using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static Weapon instance;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeColor(Color color)
    {
        //Debug.Log("무기 색 변경");
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
