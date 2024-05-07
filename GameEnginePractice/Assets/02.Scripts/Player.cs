using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   enum State {
        IDLE, WALK, RUN, HIT
    }State state;

    float moveSpeed = 5f;
    float rotSpeed = 3;

    Vector3 movement;

    float h, v;
    bool isClickLeftShift = false;

    // ������Ʈ ����
    Rigidbody ri;
    
    Animator ani;

    // ��ũ��Ʈ ����
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

        var dir = Vector3.forward;

       

        movement.Set(h, 0, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        ri.MovePosition(transform.position + movement);
        //ri.MovePosition(ri.position + transform.TransformDirection(dir) * (moveSpeed * Time.deltaTime));

        SetMoveSpeed();
        SetStateAboutMove();
        SetAni();
    }

    void Turn()
    {
        if (h == 0 && v == 0)
            return;
        movement.Set(h, 0, 0);
        Quaternion newRot = Quaternion.LookRotation(movement);

        ri.rotation = Quaternion.Slerp(ri.rotation, newRot, rotSpeed * Time.deltaTime);
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
            //Debug.Log("Left Shift ����");
            ChangeIsClickLeftShift(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ChangeIsClickLeftShift(false);
            //Debug.Log("Left Shift �հ��� ��");
        } 
    }

    /// <summary>
    /// �ִϸ��̼� ���� ������ �Ѵ�. 
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
        if (CheckIsClickLeftShift()) // Left Shift Ű�� ������ ���
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
