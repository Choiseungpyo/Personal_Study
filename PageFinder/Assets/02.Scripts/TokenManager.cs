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
        DontDestroyOnLoad(this);
        tokenUIManager = GameObject.Find("UIManager").GetComponent<TokenUIManager>();
    }
    
    /// <summary>
    /// ��ū�� �����Ѵ�.
    /// </summary>
    /// <param name="pos">��ū ���� ��ġ</param>
    public void MakeToken(Vector3 pos)
    {
        Instantiate(Token_Prefab, pos, Quaternion.identity, gameObject.transform);
    }

    /// <summary>
    /// ��ū ������ 1 ������Ų��. 
    /// </summary>
    public void IncreaseCurrentTokenCnt()
    {
        ++currentTokenCnt;
        tokenUIManager.SetCnt_Txt(currentTokenCnt);
    }

    /// <summary>
    /// ���� ��ū ������ 0���� ���½�Ų��.
    /// </summary>
    void ResetCurrentTokenCnt()
    {
        currentTokenCnt = 0;
        tokenUIManager.SetCnt_Txt(currentTokenCnt);
    }

    /// <summary>
    /// ������ū�� ��ǥ ��ū�� �����ߴ��� üũ�Ѵ�. 
    /// </summary>
    void CheckStoragedTokenHasReachedTargetToken()
    {
        if (storagedTokenCnt < tokenCntAboutNextScene)
            return;

        // ���� ��ū�� ��ǥ ��ū�� �������� ��� ó���ڵ�
        BlackHole_Obj.GetComponent<BlackHole>().SetActiveState(false); // ��Ȧ ��Ȱ��ȭ
        Portal_Obj.GetComponent<Portal>().SetActiveState(true);
        ResetStoragedTokenCnt();
    }

    /// <summary>
    /// ���� ��ū�� ���� ��ū�� �����Ѵ�. 
    /// </summary>
    public void StorageCurrentToken()
    {
        storagedTokenCnt += currentTokenCnt;
        ResetCurrentTokenCnt();
        CheckStoragedTokenHasReachedTargetToken();
    }

    /// <summary>
    /// ���� ��ū�� 0���� ���½�Ų��. 
    /// </summary>
    void ResetStoragedTokenCnt()
    {
        storagedTokenCnt = 0;
    }
}
