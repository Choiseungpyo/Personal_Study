using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    // ��ũ��Ʈ ����
    TokenManager tokenManager;
    private void Awake()
    {
        tokenManager = GameObject.Find("TokenManager").GetComponent<TokenManager>();
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (!coll.CompareTag("Player"))
            return;

        gameObject.SetActive(false);
        tokenManager.AddCurrentTokenCnt();

    }
}