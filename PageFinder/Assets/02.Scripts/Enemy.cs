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

    // ���� ������ �ѹ� �ֵθ��� �ٽ� �����ٰ� �ǵ��ƿö� �浹�� 2�� �Ǵ� ���� ���� �Ϳ� ���� ��� ó������ ����غ���

    // ������Ʈ ���� 
    Animator ani;
    SkinnedMeshRenderer skinneMeshRenderer;

    // ��ũ��Ʈ ���� 
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
        skinneMeshRenderer = gameObject.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>(); // �ڽ� ��ü polySurface1�� material�� �����ϱ� ����
    }

    private void Start()
    {
        ChangeState(State.IDLE);
        SetAniValue();
    }

    /// <summary>
    /// �浹���� ���� �����Ѵ�. 
    /// </summary>
    /// <param name="coll">�浹ü</param>
    private void OnTriggerEnter(Collider coll)
    {
        if (!coll.CompareTag("Weapon"))
            return;

        if (!player.CheckAttackAniIsPlaying())
            return;
        // �÷��̾ ���� ���� + ����� �ε����� ��
        skinneMeshRenderer.material.color = palette.ReturnCurrentColor();
        Debug.Log("Ont :" + coll.name);
        exp.IncreaseExp(50); // �÷��̾� Exp ����
        ChangeState(State.DEAD);
        SetAniValue();

        if (!isAlive)
            return;

        
        StartCoroutine(Disappear());
       
    }

    /// <summary>
    /// ���� ������� �����.
    /// </summary>
    /// <returns></returns>
    IEnumerator Disappear()
    {
        Debug.Log("�� ������� �ڷ�ƾ �۵�");
        isAlive = false;
        yield return new WaitForSeconds(1.1f);
        tokenManager.MakeToken(new Vector3(transform.position.x, 0.25f, transform.position.z));
        Die();   
    }

    /// <summary>
    /// ���� ���ش�. 
    /// </summary>
    void Die()
    {
        gameObject.transform.position = new Vector3(0, 0.5f, -10);
        ChangeActivatedState(false);
    }

    /// <summary>
    /// �÷��̾��� ���¸� �����Ѵ�. 
    /// </summary>
    /// <param name="value">������ ���� ��</param>
    void ChangeState(State value)
    {
        state = value;
    }

    /// <summary>
    /// �÷��̾��� ���ӿ�����Ʈ�� Ȱ��ȭ ���θ� �����Ѵ�.
    /// </summary>
    /// <param name="value">������ Ȱ��ȭ ����</param>
    void ChangeActivatedState(bool value)
    {
        gameObject.SetActive(value);
    }

    /// <summary>
    /// �ִϸ��̼� ���� ���� �����Ѵ�. 
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
