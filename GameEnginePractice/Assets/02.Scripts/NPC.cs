using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum NPCState
{
    IDLE, TALK
}


public class NPC : MonoBehaviour
{
    NPCState state;
    

    // 컴포넌트 관련
    Animator ani;

    //스크립트 관련
    Candy candy;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        candy = GetComponent<Candy>();
        ChangeState(NPCState.IDLE);
    }

    private void Update()
    {
        if(state== NPCState.TALK)
        {
            // 플레이어에게 캔디 주기 
        }
    }

    /// <summary>
    /// 애니메이션 관련 설정을 한다. 
    /// </summary>
    void SetAni()
    {
        switch (state)
        {
            case NPCState.IDLE:
                ani.SetBool("idle", true);
                break;
            case NPCState.TALK:
                ani.SetBool("idle", false);
                ani.SetTrigger("talk");
                break;
        }
    }

    public void ChangeState(NPCState value)
    {
        state = value;
        SetAni();
    }
    
    public string ReturnCandyType()
    {
        return candy.ReturnRandomCandy();
    }
}
