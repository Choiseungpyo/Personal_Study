using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public static Portal instance;
    private void Awake()
    {
        instance = this;
    }


    public void ChangeColor(Color color)
    {
        ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = color; // <- or whatever color you want to assign
    }

    public IEnumerator MoveNextScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("NextScene");
    }
}
