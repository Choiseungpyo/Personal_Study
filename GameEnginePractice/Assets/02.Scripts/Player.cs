using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   enum State {
        IDLE, WALK, RUN, HIT
    }State state;

    float moveSpeed = 5f;
    float turnSpeed = 100;

    Vector3 movement;

    float h, v;
    bool isClickLeftShift = false;

    // 컴포넌트 관련
    Rigidbody ri;
    
    Animator ani;

    // 스크립트 관련
    PlayerUIManager playerUIManager;

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
        if (!(h == 0 && v == 0))
            return;

        ChangeState(State.IDLE);
        SetAni();
    }

    void Move()
    {
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
        if (h == 0)
            return;
        movement.Set(h, 0, 0);
        transform.Rotate(new Vector3(0, movement.x * Time.deltaTime * turnSpeed, 0)); // 자기 자신기준 회전
    }



    void Run()
    {
        if (playerUIManager.CheckIfRunGaugeIsFull())
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
}
