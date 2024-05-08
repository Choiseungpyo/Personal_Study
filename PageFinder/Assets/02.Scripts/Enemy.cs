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

    // ������Ʈ ���� 
    Animator ani;
    SkinnedMeshRenderer skinneMeshRenderer;

    // ��ũ��Ʈ ���� 
    Player player;
    TokenManager tokenManager;
   
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        tokenManager = GameObject.Find("TokenManager").GetComponent<TokenManager>();
        ani = GetComponent<Animator>();
        skinneMeshRenderer = gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>(); // �ڽ� ��ü polySurface1�� material�� �����ϱ� ����
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
        // �÷��̾ ���� ���� + ����� �ε����� ��
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
        Debug.Log("�� ������� �ڷ�ƾ �۵�");
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
