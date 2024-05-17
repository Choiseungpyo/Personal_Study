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

    // 검이 적에게 한번 휘두르고 다시 나갔다가 되돌아올때 충돌이 2번 되는 것을 막는 것에 대해 어떻게 처리할지 고민해보기

    // 컴포넌트 관련 
    Animator ani;
    SkinnedMeshRenderer skinneMeshRenderer;

    // 스크립트 관련 
    Player player;
    Exp exp;
    TokenManager tokenManager;
    Palette palette;
   
    private void Awake()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        palette = playerObj.GetComponent<Palette>();
        exp = playerObj.GetComponent<Exp>();
        tokenManager = GameObject.Find("TokenManager").GetComponent<TokenManager>();
        ani = GetComponent<Animator>();
        skinneMeshRenderer = gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>(); // 자식 객체 polySurface1에 material이 존재하기 때문
    }

    private void Start()
    {
        ChangeState(State.IDLE);
        SetAniValue();
    }

    /// <summary>
    /// 충돌했을 때를 관리한다. 
    /// </summary>
    /// <param name="coll">충돌체</param>
    private void OnTriggerEnter(Collider coll)
    {
        if (!coll.CompareTag("Weapon"))
            return;

        if (!player.CheckAttackAniIsPlaying())
            return;
        // 플레이어가 공격 상태 + 무기와 부딪쳤을 때
        skinneMeshRenderer.material.color = palette.ReturnCurrentColor();
        Debug.Log("Ont :" + coll.name);
        exp.IncreaseExp(50); // 플레이어 Exp 증가
        ChangeState(State.DEAD);
        SetAniValue();

        if (!isAlive)
            return;

        
        StartCoroutine(Disappear());
       
    }

    /// <summary>
    /// 적을 사라지게 만든다.
    /// </summary>
    /// <returns></returns>
    IEnumerator Disappear()
    {
        Debug.Log("적 사라지는 코루틴 작동");
        isAlive = false;
        yield return new WaitForSeconds(1.1f);
        tokenManager.MakeToken(new Vector3(transform.position.x, 0.25f, transform.position.z));
        Die();   
    }

    /// <summary>
    /// 적을 없앤다. 
    /// </summary>
    void Die()
    {
        gameObject.transform.position = new Vector3(0, 0.5f, -10);
        ChangeActivatedState(false);
    }

    /// <summary>
    /// 플레이어의 상태를 변경한다. 
    /// </summary>
    /// <param name="value">변경할 상태 값</param>
    void ChangeState(State value)
    {
        state = value;
    }

    /// <summary>
    /// 플레이어의 게임오브젝트의 활성화 여부를 변경한다.
    /// </summary>
    /// <param name="value">변경할 활성화 여부</param>
    void ChangeActivatedState(bool value)
    {
        gameObject.SetActive(value);
    }

    /// <summary>
    /// 애니메이션 상태 값을 변경한다. 
    /// </summary>
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
