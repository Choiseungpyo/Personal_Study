using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TokenManager : MonoBehaviour
{
    // ������
    public GameObject Token_Prefab;

    // ����� ������Ʈ
    public GameObject BlackHole_Obj;
    public GameObject Portal_Obj;

    int currentTokenCnt = 0;
    int storagedTokenCnt = 0;

    int tokenCntAboutNextScene = 5;

    // ��ũ��Ʈ ����
    TokenUIManager tokenUIManager;
    private void Awake()
    {
        tokenUIManager = GameObject.Find("UIManager").GetComponent<TokenUIManager>();
        DontDestroyOnLoad(this);
    }


    private void Update()
    {
        CheckCurrentTokenCnt();
    }

    public void MakeToken(Vector3 pos)
    {
        Instantiate(Token_Prefab, pos, Quaternion.identity, gameObject.transform);
    }

    public void AddCurrentTokenCnt()
    {
        ++currentTokenCnt;
        tokenUIManager.SetCnt_Txt(currentTokenCnt);
    }

    void ResetCurrentTokenCnt()
    {
        currentTokenCnt = 0;
        tokenUIManager.SetCnt_Txt(currentTokenCnt);
    }

    void CheckCurrentTokenCnt()
    {
        if (storagedTokenCnt < tokenCntAboutNextScene)
            return;
        BlackHole_Obj.GetComponent<BlackHole>().SetActiveState(false); // ��Ȧ ��Ȱ��ȭ
        Portal_Obj.GetComponent<Portal>().SetActiveState(true);
        ResetStoragedTokenCnt(); 
    }

    public void StorageCurrentToken()
    {
        storagedTokenCnt += currentTokenCnt;
        ResetCurrentTokenCnt();
    }

    void ResetStoragedTokenCnt()
    {
        storagedTokenCnt = 0;
    }
}
