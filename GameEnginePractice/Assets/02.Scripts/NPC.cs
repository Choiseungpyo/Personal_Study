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

    // ���� ��ġ �ε���
    int posIndex = 0;


    // ������Ʈ ����
    Animator ani;

    //��ũ��Ʈ ����
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
        npcUIManager.ChangeCandImg(candyToGive); // �÷��̾�� �� ĵ�� �ʱ�ȭ
    }
    private void Update()
    {
        DestroyNPC();
        SetDir();

    }
    /// <summary>
    /// �ִϸ��̼� ���� ������ �Ѵ�. 
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

                // �÷��̾�� ĵ�� �ֱ�
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
