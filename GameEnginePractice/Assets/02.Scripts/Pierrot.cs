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


    // ������Ʈ ����
    Animator ani;

    // ��ũ��Ʈ ����
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
    /// �ִϸ��̼� ���� ������ �Ѵ�. 
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
        Debug.Log("Idle ���·� ��ȯ");
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
