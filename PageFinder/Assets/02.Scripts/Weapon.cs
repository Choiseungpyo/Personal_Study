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
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
