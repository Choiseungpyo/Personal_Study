using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TokenManager : MonoBehaviour
{
    public GameObject Token_Prefab;

    int tokenCnt = 0;

    // 스크립트 관련
    TokenUIManager tokenUIManager;

    private void Awake()
    {
        tokenUIManager = GameObject.Find("UIManager").GetComponent<TokenUIManager>();
      
        DontDestroyOnLoad(this);
    }


    private void Update()
    {
        CheckTokenCnt();
    }

    public void MakeToken(Vector3 pos)
    {
        Instantiate(Token_Prefab, pos, Quaternion.identity, gameObject.transform);
    }

    public void AddTokenCnt()
    {
        ++tokenCnt;
        tokenUIManager.SetCnt_Txt(tokenCnt);
    }

    void ResetTokenCnt()
    {
        tokenCnt = 0;
        tokenUIManager.SetCnt_Txt(tokenCnt);
    }

    void CheckTokenCnt()
    {
        if (tokenCnt < 5)
            return;
       
    }
}
