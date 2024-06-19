using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpecialNPC : MonoBehaviour
{
    NPCState state;

    // ������Ʈ ����
    Animator ani;

    //��ũ��Ʈ ����
    GameObject playerObj;
    PuzzleUIManager puzzleUIManager;
    NPCManager npcManager;

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        puzzleUIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<PuzzleUIManager>();
        npcManager = GameObject.Find("NPCManager").GetComponent<NPCManager>();
        ani = GetComponent<Animator>();
        ChangeState(NPCState.IDLE);
    }

    private void Update()
    {
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
                break;
            case NPCState.END:
                // �÷��̾�� ĵ�� �ֱ�
                npcManager.ChangeSpecialNPCISSpawnState(false);

                transform.parent.GetComponent<NPCManager>().MakeTalkEffect(transform.position + new Vector3(0, 1.5f, 0), puzzleUIManager.ReturnGameResult());
                Destroy(gameObject);
                break;

        }
    }

    public void ChangeState(NPCState value)
    {
        state = value;
        SetAni();
    }

    public void StartPuzzle()
    {
        puzzleUIManager.ActivatePuzzleUI();
        ChangeState(NPCState.IDLE);
    }

    void SetDir()
    {
        transform.LookAt(playerObj.transform);
    }
}
