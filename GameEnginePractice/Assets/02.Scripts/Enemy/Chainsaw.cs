using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public enum ChainsawState
{
    IDLE, FIND, CHASE, ATTACK, STUN, DEAD
}

public class Chainsaw : MonoBehaviour
{
    ChainsawState state;

    public GameObject Weapon;

    float   chaseSpeed = 5;             // �÷��̾ �߰��� �� �̵� �ӵ�
    int     playerDetectDist = 20;      // �÷��̾� ���� ����
    
    float   turnSpeed = 3f;           // �÷��̾ �ٶ� �� ȸ�� �ӵ�
    bool    canMove = true;

    // Find
    Vector3 findStartPos;
    float   findMoveDist = 7;          // Ž�� �� ������ �Ÿ�
    float   findMoveSpeed = 2.5f;
    Vector3 currentFindDir = Vector3.forward;

    string candyToTake = "";

    // �÷��̾� ����
    GameObject player;

    // ��ũ��Ʈ ����
    EnemyManager enemyManager;
    PuzzleUIManager puzzleUIManager;

    // ������Ʈ ����
    Animator ani;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        ani = GetComponent<Animator>();
        enemyManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        puzzleUIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<PuzzleUIManager>();
        candyToTake = player.GetComponent<Candy>().ReturnRandomCandy();
    }
    private void Start()
    {
        SetFindStartPos();
        ChangeState(ChainsawState.FIND);
    }
    private void Update()
    {
        if (puzzleUIManager.CheckIfCanvasIsActivated())
            return;

        FindPlayer();
        ChasePlayer();

        if (puzzleUIManager.CheckIfCanvasIsActivated())
            enemyManager.RemoveObj("enemy", gameObject);
    }

    /// <summary>
    /// �ִϸ��̼� ���� ������ �Ѵ�. 
    /// </summary>
    void SetAni()
    {
        switch (state)
        {
            case ChainsawState.IDLE:
                ani.SetBool("idle", true);
                ani.SetBool("stun", false);
                ani.SetBool("attack", false);
                break;
            case ChainsawState.FIND:
                ani.SetBool("idle", false);
                ani.SetBool("stun", false);
                ani.SetBool("attack", false);
                ani.SetTrigger("chainsawWalk");
                ani.SetTrigger("chainsawStart");
                break;
            case ChainsawState.CHASE:
                ani.SetBool("idle", false);
                ani.SetBool("stun", false);
                ani.SetBool("attack", false);
                ani.SetTrigger("chainsawRun");
                break;
            case ChainsawState.ATTACK:
                ani.SetBool("idle", false);
                ani.SetBool("stun", false);
                ani.SetBool("attack", true);
                break;
            case ChainsawState.STUN:
                ani.SetBool("idle", false);
                ani.SetBool("stun", true);
                ani.SetBool("attack", false);
                ani.SetTrigger("dead");
                break;
            case ChainsawState.DEAD:
                ani.SetBool("idle", false);
                ani.SetBool("stun", false);
                ani.SetBool("attack", false);
                break;
        }
    }

    public void ChangeState(ChainsawState value)
    {
        state = value;
        SetAni();
    }

    void FindPlayer()
    {
        if (!CheckCanMove())
        {
            if (CheckIfCurrentStateIsDesiredState(ChainsawState.STUN) || CheckIfCurrentStateIsDesiredState(ChainsawState.DEAD))
                return;
            if (!CheckIfCurrentStateIsDesiredState(ChainsawState.FIND))
                return;

            // ���� �ε��� ���
            Debug.Log("���� �ε����� ������ ���� ���� : " + ReturnReverseDir());
            ChangeCurrentFindDir(ReturnReverseDir()); // �Դ� ��������� �ݴ�������� ������ ����
            SetFindStartPos();
            ChangeCanMove(true);
            return;
        }

        if (CheckIfCurrentStateIsDesiredState(ChainsawState.CHASE) || CheckIfCurrentStateIsDesiredState(ChainsawState.STUN))
            return;

        MoveToFind();
        if (!CheckDistanceFromPlayer())
            return;
        
        //Debug.Log("Chase ����");
        
        ChangeState(ChainsawState.CHASE);
    }

    bool CheckDistanceFromPlayer()
    {
        if (Vector3.Distance(player.transform.position, transform.position) > playerDetectDist)
            return false;
        return true;
    }

    bool CheckIfCurrentStateIsDesiredState(ChainsawState value)
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

    void ChasePlayer()
    {
        if (!CheckCanMove())
        {
            LookAtPlayer();
            return;
        }
            
        if (!CheckIfCurrentStateIsDesiredState(ChainsawState.CHASE))
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
        {
            ChangeCanMove(false);
            ChangeState(ChainsawState.STUN);
            Debug.Log("���ε� �ε���");
        }
        else if (coll.collider.CompareTag("Player"))
        {
            if (CheckIfCurrentStateIsDesiredState(ChainsawState.STUN) || CheckIfCurrentStateIsDesiredState(ChainsawState.DEAD))
                return;

            ChangeCanMove(false);
            ChangeState(ChainsawState.ATTACK);
            Destroy(Weapon.GetComponent<BoxCollider>(), 0.5f);
        }
        else if (coll.collider.CompareTag("Wall"))
        {
            Debug.Log("Wall");
            ChangeCanMove(false);
        }
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.collider.CompareTag("Wall"))
        {
            //Debug.Log("Wall");
            ChangeCanMove(true);
        }
    }

    void MoveToFind()
    {
        transform.Translate(currentFindDir * Time.deltaTime * findMoveSpeed, Space.World);
        transform.LookAt(transform.position + currentFindDir);

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
    
    public void RemoveChainsaw()
    {
        enemyManager.RemoveObj("enemy", gameObject);
    }
    
    public bool CheckAttackState()
    { 
        return (state == ChainsawState.ATTACK) ? true : false;
    }

    public string ReturnCandyNameToTake()
    {
        return candyToTake;
    }
}
