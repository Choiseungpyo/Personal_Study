using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Playables;

public class TokenUIManager : MonoBehaviour
{
    
    public TMP_Text Cnt_Txt;

    // ��ũ��Ʈ ����
    TokenManager tokenManager;

    private void Awake()
    {
        tokenManager = GameObject.Find("TokenManager").GetComponent<TokenManager>();
    }

    private void Start()
    {
        SetCnt_Txt(0);
    }

    /// <summary>
    /// ��ū�� ���� �ؽ�Ʈ�� �����Ѵ�.
    /// </summary>
    /// <param name="currentTokenCnt">��ū ����</param>
    public void SetCnt_Txt(int currentTokenCnt)
    {
        Cnt_Txt.text = currentTokenCnt.ToString();
    }
}
