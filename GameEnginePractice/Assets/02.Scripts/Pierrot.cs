using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pierrot : MonoBehaviour
{
    enum State
    {
        IDLE, SCARE
    }State state;


    // 컴포넌트 관련
    Animator ani;

    // 스크립트 관련
    EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        ani = GetComponent<Animator>();
    }
    private void Start()
    {
        ChangeState(State.SCARE);
        SetAni();
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    private void Update()
    {
        TermianteScareAni();
    }

    /// <summary>
    /// 애니메이션 관련 설정을 한다. 
    /// </summary>
    void SetAni()
    {
        switch (state)
        {
            case State.IDLE:
                ani.SetBool("idle", true);
                break;
            case State.SCARE:
                ani.SetBool("idle", false);
                break;
        }
    }

    void ChangeState(State value)
    {
        state = value;
    }

    bool CheckIfScareAnIsTerminated()
    {
        if (!ani.GetCurrentAnimatorStateInfo(0).IsName("Scare"))
            return false;

        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            return false;
        return true;
    }

    void TermianteScareAni()
    {
        if (!CheckIfScareAnIsTerminated())
            return;
        Debug.Log("Idle 상태로 변환");
        ChangeState(State.IDLE);
        SetAni();
        StartCoroutine(RemovePierrot());
    }

    IEnumerator RemovePierrot()
    {
        yield return new WaitForSeconds(1f);
        enemyManager.RemoveObj("enemy", gameObject);
    }
    
}
