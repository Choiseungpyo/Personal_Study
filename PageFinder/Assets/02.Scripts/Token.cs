using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    // 스크립트 관련
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
