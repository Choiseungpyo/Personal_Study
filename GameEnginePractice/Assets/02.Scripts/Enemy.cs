using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ���ۼ���
    // 1. ���� -> Idle
    // 2. n�� �� crawl ����
    // 3. ���� 
    // 4.1 �÷��̾�� ���˽� �÷��̾� hp ���� �� �� �����
    // 4.2 3ȸ ���� �� �����

    enum State { 
        IDLE, CRAWL
    }State state;

    int hp = 10;
    int crawlSpeed = 10;
    int crawlDist = 25;

    Vector3 crawlStartPos;

    
    // ��ũ��Ʈ ����
    GameObject target;
    Player player;

    // ������Ʈ ����
    Animator ani;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        player = target.GetComponent<Player>();
    }

    private void Start()
    {
        state = State.CRAWL;
        SetAni();

        // Ÿ�� ���� ����
        SetCrawlDir();
        SetCrawlPos();
    }

    private void Update()
    {
        ChasePlayer();
        CheckCrawlDist();
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
                ani.SetBool("crawl", false);
                break;
            case State.CRAWL:
                ani.SetBool("idle", false);
                ani.SetBool("crawl", true);
                break;
        }
    }

    void ChangeState(State value)
    {
        state = value;
    }

    void ChasePlayer()
    {
        if (state != State.CRAWL)
            return;
        
        transform.Translate(Vector3.forward * Time.deltaTime * crawlSpeed);
    }

    void CheckCrawlDist()
    {
        if (state != State.CRAWL)
            return;
        if (Vector3.Distance(transform.position, crawlStartPos) < crawlDist)
            return;
        ChangeState(State.IDLE);
        SetAni();

        StartCoroutine(ReCrawl());
    }

    IEnumerator ReCrawl()
    {
        yield return new WaitForSeconds(2);

        ChangeState(State.CRAWL);
        SetAni();
        SetCrawlDir();
        SetCrawlPos();
    }

    void SetCrawlDir()
    {
        transform.LookAt(target.transform);
    }

    void SetCrawlPos()
    {
        crawlStartPos = transform.position;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (!coll.CompareTag("Player"))
            return;

        player.ChangeHp(1);
        Destroy(gameObject);
    }
}
