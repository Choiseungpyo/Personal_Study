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
    // 나중에 충돌, 움직임, 상태 전부 클래스 나누기


    public enum State { 
        IDLE, RUN, ATTACK
    }State state;

    int speed = 10;
    Animator ani;
    Rigidbody ri;
    Vector3 movement;

    // 포탈 관련
    bool isContactWithPortal = false;

    // 스크립트 관련
    Portal portal;
    Palette palette;
    TokenManager tokenManager;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        // 스크립트 관련
        portal = GameObject.Find("Portal").GetComponent<Portal>();
        palette = GameObject.FindWithTag("Player").GetComponent<Palette>();
        tokenManager = GameObject.Find("TokenManager").GetComponent<TokenManager>();

        // 컴포넌트 관련
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
        // 아무 움직임도 하지 않을 경우
        if (v == 0 && h == 0)
        {
            ChangePlayerState(State.IDLE);
            SetAniValue();
            //Debug.Log("어떠한 키도 누르지 않음");
            return;
        }

        if (CheckAttackAniIsPlaying())
            return;

        // 움직일 경우

        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        ri.MovePosition(transform.position + movement);

        if (v != 0)
        {
            if (v > 0) // 상
            {
                ChangePlayerState(State.RUN);
                SetAniValue();
            }
            else if (v < 0) // 하
            {
                ChangePlayerState(State.RUN);
                SetAniValue();
            }
        }

        if (h != 0)
        {
            if (h < 0) // 좌
            {
                ChangePlayerState(State.RUN);
                SetAniValue();
            }
            else if (h < 0) // 우
            {
                ChangePlayerState(State.RUN);
                SetAniValue();
            }
        }
    }

    /// <summary>
    /// 플레이어의 몸을 회전시킨다. 
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
    /// 플레이어의 상태를 변경한다. 
    /// </summary>
    /// <param name="value">변경할 상태</param>
    void ChangePlayerState(State value)
    {
        state = value; 
    }

    /// <summary>
    /// 애니메이션 값을 변경한다. 
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
    /// 공격을 관리한다. 
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
    /// 현재 상태를 리턴한다. 
    /// </summary>
    /// <returns></returns>
    public State ReturnState()
    {
        return state;
    }

    /// <summary>
    /// 공격 애니메이션이 동작중인지 체크한다. 
    /// </summary>
    /// <returns></returns>
    public bool CheckAttackAniIsPlaying()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return true;
        return false;
    }

    /// <summary>
    /// 충돌할 때를 관리한다.
    /// </summary>
    /// <param name="coll">충돌체</param>
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
    /// 충돌 후 빠져 나갈때를 관리한다
    /// </summary>
    /// <param name="coll">충돌체</param>
    private void OnTriggerExit(Collider coll)
    {

        if (coll.name.Equals("Portal"))
        {
            ChangeIsContactWithPortal(false);
        }
    }

    /// <summary>
    /// 포탈과 접촉했는지의 변수를 변경한다. 
    /// </summary>
    /// <param name="value"></param>
    void ChangeIsContactWithPortal(bool value)
    {
        isContactWithPortal = value;
    }

}
