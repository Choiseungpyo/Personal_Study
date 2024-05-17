using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{

    // ��ũ��Ʈ ����
    ReinforceUIManager reinforceUIManager;

    private void Awake()
    {
        reinforceUIManager = GameObject.Find("UIManager").GetComponent<ReinforceUIManager>();
    }
    private void Start()
    {
        SetActiveState(false);
        SceneManager.sceneLoaded += LoadedSceneEvent;
    }

    /// <summary>
    /// ��Ż�� ������ �����Ѵ�. 
    /// </summary>
    /// <param name="color">������ ��</param>
    public void ChangeColor(Color color)
    {
        ParticleSystem.MainModule main = GetComponent<ParticleSystem>().main;
        main.startColor = color; // <- or whatever color you want to assign    
        StartCoroutine(MoveNextScene());
    }

    /// <summary>
    /// ���������� ��ȯ�Ѵ�. 
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveNextScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Scene1");
    }

    /// <summary>
    /// ��Ż Ȱ��ȭ/��Ȱ��ȭ ���θ� �����Ѵ�. 
    /// </summary>
    /// <param name="value">������ Ȱ��ȭ ����</param>
    public void SetActiveState(bool value)
    {
        gameObject.SetActive(value);
    }

    /// <summary>
    /// ���� �ε��� �� �̺�Ʈ�� ó���Ѵ�. 
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    void LoadedSceneEvent(Scene scene, LoadSceneMode mode)
    {
        reinforceUIManager.StartCoroutine(reinforceUIManager.ActivateReinforceUI()); // ��� �ý��� UI ����
    }
}
