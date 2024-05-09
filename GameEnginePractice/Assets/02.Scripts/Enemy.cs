using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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

    int hp = 10;
    int crawlSpeed = 10;
    int crawlDist = 25;

    Vector3 crawlStartPos;

    
    // 스크립트 관련
    GameObject target;
    Player player;

    // 컴포넌트 관련
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

        // 타겟 방향 설정
        SetCrawlDir();
        SetCrawlPos();
    }

    private void Update()
    {
        ChasePlayer();
        CheckCrawlDist();
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
