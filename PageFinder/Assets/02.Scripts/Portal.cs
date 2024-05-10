using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void Start()
    {
        SetActiveState(false);
    }

    public void ChangeColor(Color color)
    {
        ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = color; // <- or whatever color you want to assign    
        StartCoroutine(MoveNextScene());
    }


    public IEnumerator MoveNextScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Scene1");
    }

    public void SetActiveState(bool value)
    {
        gameObject.SetActive(value);
    }
}
