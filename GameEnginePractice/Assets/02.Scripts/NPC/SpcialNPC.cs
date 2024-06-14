using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class SpecialNPC : MonoBehaviour
{
    NPCState state;

    // 컴포넌트 관련
    Animator ani;

    //스크립트 관련
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
                break;
            case NPCState.END:
                // 플레이어에게 캔디 주기
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
