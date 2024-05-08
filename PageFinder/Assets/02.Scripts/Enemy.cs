using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State
    {
        IDLE, DEAD
    }State state;

    bool isAlive = true;

    // 컴포넌트 관련 
    Animator ani;
    SkinnedMeshRenderer skinneMeshRenderer;

    // 스크립트 관련 
    Player player;
    TokenManager tokenManager;
   
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        tokenManager = GameObject.Find("TokenManager").GetComponent<TokenManager>();
        ani = GetComponent<Animator>();
        skinneMeshRenderer = gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>(); // 자식 객체 polySurface1에 material이 존재하기 때문
    }

    private void Start()
    {
        ChangeState(State.IDLE);
        SetAniValue();
    }


    private void OnTriggerStay(Collider coll)
    {
        if (!coll.CompareTag("Weapon"))
            return;
        //Debug.Log(GameObject.Find("Player").GetComponent<Player>().ReturnState());
        if (!player.CheckAttackAniIsPlaying())
            return;
        // 플레이어가 공격 상태 + 무기와 부딪쳤을 때
        //gameObject.GetComponent<MeshRenderer>().material.color = Palette.instance.ReturnCurrentColor();
        skinneMeshRenderer.material.color = Palette.instance.ReturnCurrentColor();
        ChangeState(State.DEAD);
        SetAniValue();

        if (!isAlive)
            return;
       
        StartCoroutine(Disappear());
       
    }


    IEnumerator Disappear()
    {
        Debug.Log("적 사라지는 코루틴 작동");
        isAlive = false;
        yield return new WaitForSeconds(1.1f);
        tokenManager.MakeToken(new Vector3(transform.position.x, 0.25f, transform.position.z));
        Die();   
    }

    void Die()
    {
        gameObject.transform.position = new Vector3(0, 0.5f, -10);
        gameObject.SetActive(false);
    }

    void ChangeState(State value)
    {
        state = value;
    }

    void SetAniValue()
    {
        switch (state)
        {
            case State.IDLE:
                ani.SetBool("isIdle", true);
                break;
            case State.DEAD:
                ani.SetBool("isIdle", false);
                ani.SetTrigger("Dead");
                break;
        }
    }
}
