using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPCState
{
    IDLE, TALK, END
}


public class NPC : MonoBehaviour
{
    NPCState state;

    string candyToGive = "";

    // 스폰 위치 인덱스
    int posIndex = 0;

    int candyCntToGive = 0;

    // 컴포넌트 관련
    Animator ani;

    //스크립트 관련
    Player player;
    Candy playerCandy;
    NPCUIManager npcUIManager;

    private void Awake()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        ani = GetComponent<Animator>(); 
        npcUIManager = GetComponent<NPCUIManager>();
        playerCandy = playerObj.GetComponent<Candy>();
        player = playerObj.GetComponent<Player>();
        ChangeState(NPCState.IDLE);
    }

    private void Start()
    {
        candyToGive = playerCandy.ReturnRandomCandy();
        candyCntToGive = Random.Range(1, 4);
        npcUIManager.SetCandyData(candyToGive, candyCntToGive); // 플레이어에게 줄 캔디 초기화
    }
    private void Update()
    {
        ChangeEndState();
        SetDir();
    }
    /// <summary>
    /// 애니메이션 관련 설정을 한다. 
    /// </summary>
    void SetAni()
    {
        switch (state)
        {
            case NPCState.IDLE:
                break;
            case NPCState.TALK:
                ani.SetTrigger("talk");
                ani.SetTrigger("end");
                break;
            case NPCState.END:
                // 플레이어에게 캔디 주기
                playerCandy.ChangeCandyCnt(candyToGive, candyCntToGive);
        
                transform.parent.GetComponent<NPCManager>().DeactivateNPCIndexState(posIndex);
                transform.parent.GetComponent<NPCManager>().MakeTalkEffect(transform.position + new Vector3(0, 1.5f, 0), "GetCandy");
                Destroy(gameObject);
                break;

        }
    }

    public void ChangeState(NPCState value)
    {
        state = value;
        SetAni();
    }

    void ChangeEndState()
    {
        if (state == NPCState.END)
            return;

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("end"))
        {
            
            player.ChangeDidGetCandyState(false);
            ChangeState(NPCState.END);
        }
    }

    public void ChangePosIndex(int value)
    {
        posIndex = value;
    }

    void SetDir()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }
}
