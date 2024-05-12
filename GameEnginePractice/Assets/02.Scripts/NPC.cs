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
    

    // ������Ʈ ����
    Animator ani;

    //��ũ��Ʈ ����
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
            // �÷��̾�� ĵ�� �ֱ� 
        }
    }

    /// <summary>
    /// �ִϸ��̼� ���� ������ �Ѵ�. 
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
