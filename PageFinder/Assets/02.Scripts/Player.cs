using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;



public class Player : MonoBehaviour
{
    public enum State { 
        IDLE, RUN, ATTACK
    }State state;

    int speed = 10;
    Animator ani;
    Rigidbody ri;
    Vector3 movement;

    // ��Ż ����
    bool isContactWithPortal = false;

    // ��ũ��Ʈ ����
    Portal portal;
    Palette palette;


    private void Awake()
    {
        // ��ũ��Ʈ ����
        portal = GameObject.Find("Portal").GetComponent<Portal>();
        palette = GameObject.Find("Player").GetComponent<Palette>();

        // ������Ʈ ����
        ri = GetComponent<Rigidbody>(); 
        ani = GetComponent<Animator>();


        transform.position = new Vector3(0, 0, 3);
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        Attack();
    }


    private void FixedUpdate()
    {
        //Debug.Log("����� ���� : " + colorToUse);
        //Debug.Log("�� ���� : " + groundColor);


        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Run(h,v);
        Rotate();
        
        //Debug.Log(groundColor);
    }

    void Run(float h, float v)
    {
        if (v == 0 && h == 0)
        {
            if (CheckAttackAniIsPlaying())
                return;

            ChangePlayerState(State.IDLE);
            SetAniValue();
            //Debug.Log("��� Ű�� ������ ����");
            return;
        }


        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        ri.MovePosition(transform.position + movement);

        if (v != 0)
        {
            if (v > 0) // ��
            {
                ChangePlayerState(State.RUN);
                SetAniValue();
            }
            else if (v < 0) // ��
            {
                ChangePlayerState(State.RUN);
                SetAniValue();
            }
        }

        if (h != 0)
        {
            if (h < 0) // ��
            {
                ChangePlayerState(State.RUN);
                SetAniValue();
            }
            else if (h < 0) // ��
            {
                ChangePlayerState(State.RUN);
                SetAniValue();
            }
        }
    }

    void Rotate()
    {
        int Rotspeed = 5;
        Quaternion newRotation = Quaternion.LookRotation(movement);
        ri.rotation = Quaternion.Slerp(ri.rotation, newRotation, Rotspeed * Time.deltaTime);
    }

    void ChangePlayerState(State value)
    {
        state = value; 
    }

    void SetAniValue()
    {
        switch(state)
        {
            case State.IDLE:
                ani.SetBool("isIdle", true);
                ani.SetBool("isRun", false);
                ani.SetBool("isAttack", false);
                break;
            case State.RUN:
                ani.SetBool("isIdle", false);
                ani.SetBool("isRun", true);
                ani.SetBool("isAttack", false);
                break;
            case State.ATTACK:
                ani.SetBool("isIdle", false);
                ani.SetBool("isRun", false);
                ani.SetBool("isAttack", true);
                break;
        }
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            ChangePlayerState(State.ATTACK);
            SetAniValue();

            if (!isContactWithPortal)
                return;

            portal.ChangeColor(palette.ReturnCurrentColor());
        }
    }

    public State ReturnState()
    {
        return state;
    }

    public bool CheckAttackAniIsPlaying()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return true;
        return false;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (!coll.name.Equals("Portal"))
            return;
        Debug.Log("��Ż�� �浹��");
        ChangeIsContactWithPortal(true);
    }

    private void OnTriggerExit(Collider coll)
    {
        if (!coll.name.Equals("Portal"))
            return;

        ChangeIsContactWithPortal(false);
    }

    void ChangeIsContactWithPortal(bool value)
    {
        isContactWithPortal = value;
    }
}
