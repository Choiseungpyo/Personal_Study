using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

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


    int crawlSpeed = 10;
    int crawlDist = 15;
    int crawlCnt = 0; // �� Ƚ��
    int goalCntToCrawl = 3;
    Vector3 crawlStartPos;


    // ��ũ��Ʈ ����
    GameObject target;
    Player player;
    EnemyManager enemyManager;


    // ������Ʈ ����
    Animator ani;
    private void Awake()
    {
        ani = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
        player = target.GetComponent<Player>();
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
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
        CheckGoalCntToCrawl();
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
        if(CheckCrawlDist())
        {
            ChangeState(State.IDLE);
            SetAni();
            AddCrawlCnt();
            StartCoroutine(ReCrawl());
            return;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * crawlSpeed);
    }

    bool CheckCrawlDist()
    {
        if (Vector3.Distance(transform.position, crawlStartPos) < crawlDist)
            return false;
        return true;
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
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Wall"))
        {
            // ���� ����� �� ������ ���߰� �ٽ� �÷��̾� ����
            //ChangeState(State.IDLE);
            //SetAni();
            //AddCrawlCnt();
            //StartCoroutine(ReCrawl());
            Destroy(gameObject);
        }
        else if(coll.collider.CompareTag("Player"))
        {
            player.ChangeHp(1);
            Destroy(gameObject);
            enemyManager.RemoveObj("enemy", gameObject);
        }
    }

    void AddCrawlCnt()
    {
        ++crawlCnt;
    }

    void ResetCrawlCnt()
    {
        crawlCnt = 0;
    }

    void CheckGoalCntToCrawl()
    {
        if (crawlCnt < goalCntToCrawl)
            return;
        Debug.Log("���� ����");
        ResetCrawlCnt();
        StartCoroutine(RemoveEnemy());
    }

    IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(1f);
        enemyManager.RemoveObj("enemy", gameObject);
    }


}
