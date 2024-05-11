using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum State
{
    IDLE, FIND, CHASE, ATTACK, STUN, DEAD
}

public class Chainsaw : MonoBehaviour
{
    State state;

    float   chaseSpeed = 5;             // 플레이어를 추격할 때 이동 속도
    int     playerDetectDist = 20;      // 플레이어 감지 범위
    
    float   turnSpeed = 1.5f;           // 플레이어를 바라볼 때 회전 속도
    bool    canMove = true;

    // Find
    Vector3 findStartPos;
    float   findMoveDist = 7;          // 탐지 시 움직일 거리
    float   findMoveSpeed = 2.5f;
    Vector3 currentFindDir = Vector3.forward;



    // 플레이어 관련
    GameObject player;

    // 컴포넌트 관련
    Animator ani;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        ani = GetComponent<Animator>();
        
    }
    private void Start()
    {
        SetFindStartPos();
        ChangeState(State.FIND);

    }
    private void Update()
    {
        Debug.Log(state);
        FindPlayer();
        ChasePlaeyr();
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
                ani.SetBool("stun", false);
                ani.SetBool("attack", false);
                break;
            case State.FIND:
                ani.SetBool("idle", false);
                ani.SetBool("stun", false);
                ani.SetBool("attack", false);
                ani.SetTrigger("chainsawWalk");
                ani.SetTrigger("chainsawStart");
                break;
            case State.CHASE:
                ani.SetBool("idle", false);
                ani.SetBool("stun", false);
                ani.SetBool("attack", false);
                ani.SetTrigger("chainsawRun");
                break;
            case State.ATTACK:
                ani.SetBool("idle", false);
                ani.SetBool("stun", false);
                ani.SetBool("attack", true);
                break;
            case State.STUN:
                ani.SetBool("idle", false);
                ani.SetBool("stun", true);
                ani.SetBool("attack", false);
                ani.SetTrigger("dead");
                break;
            case State.DEAD:
                ani.SetBool("idle", false);
                ani.SetBool("stun", false);
                ani.SetBool("attack", false);
                break;
        }
    }

    public void ChangeState(State value)
    {
        state = value;
        SetAni();
    }

    void FindPlayer()
    {
        if (!CheckCanMove())
        {
            if (CheckIfCurrentStateIsDesiredState(State.STUN) || CheckIfCurrentStateIsDesiredState(State.DEAD))
                return;
            if (!CheckIfCurrentStateIsDesiredState(State.FIND))
                return;

            // 벽에 부딪힌 경우
            Debug.Log("벽에 부딪혀서 진행할 방향 변경 : " + ReturnReverseDir());
            ChangeCurrentFindDir(ReturnReverseDir()); // 왔던 진행방향의 반대방향으로 가도록 설정
            SetFindStartPos();
            ChangeCanMove(true);
            return;
        }
           
        MoveToFind();
        if (!CheckDistanceFromPlayer())
            return;
        
        //Debug.Log("Chase 시작");
        
        ChangeState(State.CHASE);
    }

    bool CheckDistanceFromPlayer()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > playerDetectDist)
            return false;
        return true;
    }

    bool CheckIfCurrentStateIsDesiredState(State value)
    {
        if (state != value)
            return false;
        return true;
    }

    void LookAtPlayer()
    {
        Vector3 dir = (player.transform.position - transform.position).normalized;
        Quaternion targetDir = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetDir, Time.deltaTime * turnSpeed);
        //transform.LookAt(player.transform);
    }

    void ChasePlaeyr()
    {
        if (!CheckCanMove())
        {
            LookAtPlayer();
            return;
        }
            
        if (!CheckIfCurrentStateIsDesiredState(State.CHASE))
            return;
        LookAtPlayer();

        Vector3 dir = (player.transform.position - transform.position).normalized;
        Vector3 movement = dir * chaseSpeed * Time.deltaTime;
        transform.position += movement;
    }

    bool CheckCanMove()
    {
        return canMove ? true : false;
    }

    void ChangeCanMove(bool value)
    {
        canMove = value;
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Object"))
            ChangeState(State.STUN);
        else if (coll.collider.CompareTag("Player"))
        {
            ChangeCanMove(false);
            ChangeState(State.ATTACK);
        }
        else if (coll.collider.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            ChangeCanMove(false);
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            ChangeCanMove(true);
            ChangeState(State.CHASE);
        }
        else if (coll.collider.CompareTag("Wall"))
        {
            //Debug.Log("Wall");
            ChangeCanMove(true);
        }
    }

    void MoveToFind()
    {
        transform.Translate(currentFindDir * Time.deltaTime * findMoveSpeed);
        if (!CheckFindMoveDist())
            return;
        SetRandomDir();
        SetFindStartPos();
    }

    bool CheckFindMoveDist()
    {
        float dist = Vector3.Distance(transform.position, findStartPos);
        if (dist < findMoveDist)
            return false;
        return true;
    }

    void SetFindStartPos()
    {
        findStartPos = transform.position;
    }

    int ReturnReverseDir()
    {
        if (currentFindDir == Vector3.forward)
            return 1;
        else if (currentFindDir == Vector3.back)
            return 0;
        else if (currentFindDir == Vector3.left)
            return 3;
        else if (currentFindDir == Vector3.right)
            return 2;
        else
            return 1;
    }

    void SetRandomDir()
    {
        int randDir = Random.Range(0,4); // 0 ~ 4
        while (randDir == ReturnV3ToInt())
            randDir = Random.Range(0,4);

        ChangeCurrentFindDir(randDir);
    }

    void ChangeCurrentFindDir(int value)
    {
        Vector3 tmp;
        switch(value)
        {
            case 0:
                tmp = Vector3.forward;
                break;
            case 1:
                tmp = Vector3.back;
                break;
            case 2:
                tmp = Vector3.left;
                break;
            case 3:
                tmp = Vector3.right;
                break;
            default:
                Debug.LogWarning(value);
                tmp = Vector3.forward;
                break;

        }
        currentFindDir = tmp;
    }

    int ReturnV3ToInt()
    {
        if (currentFindDir == Vector3.forward)
            return 0;
        else if (currentFindDir == Vector3.back)
            return 1;
        else if (currentFindDir == Vector3.left)
            return 2;
        else if (currentFindDir == Vector3.right)
            return 3;
        else 
            return 0;
    }



    /*
     * 1. 이동 방향 정하기 
     * 2. 자기 자신 기준으로 v3.forward 
     * 3. 탐색 거리 확인
     * 4. 탐색 거리 도달시 1번으로 loop
     * 
     * 
     * 
     * 
     * 
     */
}
