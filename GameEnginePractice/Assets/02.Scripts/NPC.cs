using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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


    // 컴포넌트 관련
    Animator ani;

    //스크립트 관련
    Candy playerCandy;
    NPCUIManager npcUIManager;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        npcUIManager = GetComponent<NPCUIManager>();
        playerCandy = GameObject.FindGameObjectWithTag("Player").GetComponent<Candy>();
        ChangeState(NPCState.IDLE);
    }

    private void Start()
    {
        candyToGive = playerCandy.ReturnRandomCandy();
        npcUIManager.ChangeCandImg(candyToGive); // 플레이어에게 줄 캔디 초기화
    }
    private void Update()
    {
        DestroyNPC();
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

                // 플레이어에게 캔디 주기
                playerCandy.ChangeCandyCnt(candyToGive, 1);
                break;
            case NPCState.END:
                Destroy(gameObject);
                break;

        }
    }

    public void ChangeState(NPCState value)
    {
        state = value;
        SetAni();
    }

    void DestroyNPC()
    {
        if (state == NPCState.END)
            return;

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("end"))
            ChangeState(NPCState.END);
    }

    private void OnDestroy()
    {
        if(transform.parent != null)
        {
            transform.parent.GetComponent<NPCManager>().DeactivateNPCIndexState(posIndex);
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
