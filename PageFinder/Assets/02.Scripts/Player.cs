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
    // ���߿� �浹, ������, ���� ���� Ŭ���� ������


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
    TokenManager tokenManager;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        // ��ũ��Ʈ ����
        portal = GameObject.Find("Portal").GetComponent<Portal>();
        palette = GameObject.FindWithTag("Player").GetComponent<Palette>();
        tokenManager = GameObject.Find("TokenManager").GetComponent<TokenManager>();

        // ������Ʈ ����
        ri = GetComponent<Rigidbody>(); 
        ani = GetComponent<Animator>();

        transform.position = new Vector3(0, 0, 3);
    }

    private void Update()
    {
        Attack();
    }


    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Run(h,v);
        Rotate();
    }

    void Run(float h, float v)
    {
        // �ƹ� �����ӵ� ���� ���� ���
        if (v == 0 && h == 0)
        {
            ChangePlayerState(State.IDLE);
            SetAniValue();
            //Debug.Log("��� Ű�� ������ ����");
            return;
        }

        if (CheckAttackAniIsPlaying())
            return;

        // ������ ���

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

    /// <summary>
    /// �÷��̾��� ���� ȸ����Ų��. 
    /// </summary>
    void Rotate()
    {
        if (CheckAttackAniIsPlaying())
            return;

        int Rotspeed = 5;
        Quaternion newRotation = Quaternion.LookRotation(movement);
        ri.rotation = Quaternion.Slerp(ri.rotation, newRotation, Rotspeed * Time.deltaTime);
    }

    /// <summary>
    /// �÷��̾��� ���¸� �����Ѵ�. 
    /// </summary>
    /// <param name="value">������ ����</param>
    void ChangePlayerState(State value)
    {
        state = value; 
    }

    /// <summary>
    /// �ִϸ��̼� ���� �����Ѵ�. 
    /// </summary>
    void SetAniValue()
    {
        switch(state)
        {
            case State.IDLE:
                ani.SetBool("isIdle", true);
                ani.SetBool("isRun", false);
                break;
            case State.RUN:
                ani.SetBool("isIdle", false);
                ani.SetBool("isRun", true);
                break;
            case State.ATTACK:
                ani.SetBool("isIdle", false);
                ani.SetBool("isRun", false);
                ani.SetTrigger("attack");
                break;
        }
    }

    /// <summary>
    /// ������ �����Ѵ�. 
    /// </summary>
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangePlayerState(State.ATTACK);
            SetAniValue();

            if (!isContactWithPortal)
                return;

            portal.ChangeColor(palette.ReturnCurrentColor());
        }
    }

    /// <summary>
    /// ���� ���¸� �����Ѵ�. 
    /// </summary>
    /// <returns></returns>
    public State ReturnState()
    {
        return state;
    }

    /// <summary>
    /// ���� �ִϸ��̼��� ���������� üũ�Ѵ�. 
    /// </summary>
    /// <returns></returns>
    public bool CheckAttackAniIsPlaying()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return true;
        return false;
    }

    /// <summary>
    /// �浹�� ���� �����Ѵ�.
    /// </summary>
    /// <param name="coll">�浹ü</param>
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.name.Equals("BlackHole"))
        {
            tokenManager.StorageCurrentToken();
        }
        else if (coll.name.Equals("Portal"))
        {
            ChangeIsContactWithPortal(true);
        }  
    }

    /// <summary>
    /// �浹 �� ���� �������� �����Ѵ�
    /// </summary>
    /// <param name="coll">�浹ü</param>
    private void OnTriggerExit(Collider coll)
    {

        if (coll.name.Equals("Portal"))
        {
            ChangeIsContactWithPortal(false);
        }
    }

    /// <summary>
    /// ��Ż�� �����ߴ����� ������ �����Ѵ�. 
    /// </summary>
    /// <param name="value"></param>
    void ChangeIsContactWithPortal(bool value)
    {
        isContactWithPortal = value;
    }

}
