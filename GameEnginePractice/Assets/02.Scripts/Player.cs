using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
   enum State {
        IDLE, WALK, RUN, HIT, TALK
    }State state;

    int hp = 10;

    float moveSpeed = 5f;
    float turnSpeed = 100;

    Vector3 movement;

    float h, v;
    bool isClickLeftShift = false;

    bool didGetCandy = false;

    // NPC 관련
    GameObject npc = null;

    // 컴포넌트 관련
    Rigidbody ri;
    Animator ani;

    // 스크립트 관련
    PlayerUIManager playerUIManager;
    [HideInInspector]

    private void Awake()
    {
        playerUIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<PlayerUIManager>();
        ri = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();

        ani.SetBool("idle", false);
        ani.SetBool("walk", false);
        ani.SetBool("run", false);
    }

    private void Update()
    {
        Run();
        ChangeHitAniToIdleAni();
        TalkNPC();
        ChangeIdleState();            
    }

    private void FixedUpdate()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        Idle();
        Move();
        
        Turn();
    }

    void Idle()
    {
        if (state == State.HIT || state == State.TALK)
            return;

        if (!(h == 0 && v == 0))
            return;

        ChangeState(State.IDLE);
        SetAni();
    }

    void Move()
    {
        if (state == State.HIT || state == State.TALK)
            return;

        if (h == 0 && v == 0)
            return;


        movement.Set(h, 0, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        transform.Translate(movement); // 월드좌표 대신 자기자신 기준으로 이동
        SetMoveSpeed();
        SetStateAboutMove();
        SetAni();
    }

    void Turn()
    {
        if (state == State.HIT || state == State.TALK)
            return;
        if (h == 0)
            return;

        movement.Set(h, 0, 0);
        transform.Rotate(new Vector3(0, movement.x * Time.deltaTime * turnSpeed, 0)); // 자기 자신기준 회전
    }



    void Run()
    {
        if (state == State.HIT || state == State.TALK)
            return;
        if (playerUIManager.CheckIfRunGaugeHasRunOut())
        {
            ChangeIsClickLeftShift(false);
            return;
        }
           

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("Left Shift 누름");
            ChangeIsClickLeftShift(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ChangeIsClickLeftShift(false);
            //Debug.Log("Left Shift 손가락 뗌");
        } 
    }

    /// <summary>
    /// 애니메이션 관련 설정을 한다. 
    /// </summary>
    void SetAni()
    {
        switch(state)
        {
            case State.IDLE:
                ani.SetBool("idle", true);
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                break;
            case State.WALK:
                ani.SetBool("idle", false);
                ani.SetBool("walk", true);
                ani.SetBool("run", false);
                break;
            case State.RUN:
                ani.SetBool("idle", false);
                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                break;
            case State.HIT:
                ani.SetBool("idle", false);
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetTrigger("hit");
                break;
            case State.TALK:
                ani.SetBool("idle", false);
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetTrigger("talk");
                break;
        }
    }

    void ChangeState(State value)
    {
        state = value;
    }

    void SetStateAboutMove()
    {
        if (CheckIsClickLeftShift())
            ChangeState(State.RUN);
        else
            ChangeState(State.WALK);
    }

    void ChangeIsClickLeftShift(bool value)
    {
        isClickLeftShift = value;
    }

    bool CheckIsClickLeftShift()
    {
        return isClickLeftShift ? true : false;
    }

    void ChangeMoveSpeed(float value)
    {
        moveSpeed = value;
    }

    void SetMoveSpeed()
    {
        if (CheckIsClickLeftShift()) // Left Shift 키를 눌렀을 경우
            ChangeMoveSpeed(10.0f);
        else
            ChangeMoveSpeed(5.0f);
    }

    public bool CheckIfCurrentStateIsRun()
    {
        if (state == State.RUN)
            return true;
        return false;
    }

    /// <summary>
    /// 플레이어의 Hp를 변경한다. 
    /// </summary>
    /// <param name="value">감소시킬 hp 값</param>
    public void ChangeHp(int value)
    {
        hp -= value;
        Debug.Log("플레이어 Hp : " + hp);
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("NPC"))
        {
            npc = coll.gameObject;

            // TALK 애니메이션 끝나고 IDLE 상태로 바꾸고 움직일 수 있게 만드는 코드 작성해야함. 
        }
        if (coll.collider.CompareTag("Enemy"))
        {
            ChangeState(State.HIT);
            SetAni();
            //StartCoroutine(ChangeHitAniToIdleAni());
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.collider.CompareTag("NPC"))
            npc = null;
    }


    bool CheckIfHitAniIsTerminated()
    {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            return false;
        //Debug.Log("Hit Ani 동작");
        if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            return false;
        //Debug.Log("Hit Ani 종료");
        return true;
    }

    void ChangeHitAniToIdleAni()
    {
        if (state != State.HIT)
            return;

        if (!CheckIfHitAniIsTerminated())
            return;

        ChangeState(State.IDLE);
        SetAni();
    }

    bool CheckIfItIsContactWithNPC()
    {
        return npc != null ? true : false;
    }

    void TalkNPC()
    {
        if (!CheckIfItIsContactWithNPC())
            return;
        if(Input.GetKeyDown(KeyCode.R) && !ReturnDidGetCandyState())
        {
            ChangeDidGetCandyState(true);
            // 플레이어 애니메이션 재생
            ChangeState(State.TALK);
            SetAni();
            // NPC  애니메이션 재생
            npc.GetComponent<NPC>().ChangeState(NPCState.TALK);
        }
    }

    void ChangeIdleState()
    {
        if (state != State.TALK)
            return;

        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Talk") && ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            ChangeState(State.IDLE);
    }
  
    public void ChangeDidGetCandyState(bool value)
    {
        didGetCandy = value;
    }

    bool ReturnDidGetCandyState()
    {
        return didGetCandy;
    }
}
