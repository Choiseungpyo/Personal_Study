using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class Enemy : MonoBehaviour
{
    // 동작순서
    // 1. 생성 -> Idle
    // 2. n초 후 crawl 변경
    // 3. 돌진 
    // 4.1 플레이어와 접촉시 플레이어 hp 감소 및 적 사라짐
    // 4.2 3회 돌진 후 사라짐

    enum State { 
        IDLE, CRAWL
    }State state;


    int crawlSpeed = 10;
    int crawlDist = 25;
    int crawlCnt = 0; // 기어간 횟수
    int goalCntToCrawl = 3;
    Vector3 crawlStartPos;



    
    // 스크립트 관련
    GameObject target;
    Player player;
    EnemyManager enemyManager;

    // 컴포넌트 관련
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

        // 타겟 방향 설정
        SetCrawlDir();
        SetCrawlPos();
    }

    private void Update()
    {
        ChasePlayer();
        CheckCrawlDist();
        CheckGoalCntToCrawl();
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
        AddCrawlCnt();
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
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Wall"))
        {
            // 벽과 닿았을 때 움직임 멈추고 다시 플레이어 조준
            ChangeState(State.IDLE);
            SetAni();
            AddCrawlCnt();
            StartCoroutine(ReCrawl());
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
        //Debug.Log("적 삭제 예정");
        ResetCrawlCnt();
        StartCoroutine(RemoveEnemy());
    }

    IEnumerator RemoveEnemy()
    {
        yield return new WaitForSeconds(1f);
        enemyManager.RemoveObj("enemy", gameObject);
    }


}
