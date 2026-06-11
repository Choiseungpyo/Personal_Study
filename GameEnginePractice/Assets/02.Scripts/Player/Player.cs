using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<float> OnRunGaugeChanged;

    [SerializeField] private AudioSource[] audioSource = new AudioSource[2];

    private PlayerState idleState = new PlayerIdleState();
    private PlayerState walkState = new PlayerWalkState();
    private PlayerState runState = new PlayerRunState();
    private PlayerState hitState = new PlayerHitState();
    private PlayerState talkState = new PlayerTalkState();
    private PlayerState currentState;

    private float walkSpeed = 5f;
    private float runSpeed = 10f;
    private float turnSpeed = 500f;
    private float runGauge = 1f;
    private float runGaugeSpeed = 0.5f;
    private float h = 0f;
    private float v = 0f;
    private bool isRunPressed = false;
    private bool didGetCandy = false;
    private Vector3 movement;
    private GameObject npc = null;
    private Animator ani;
    private Candy candy;

    public PlayerState IdleState => idleState;
    public PlayerState WalkState => walkState;
    public PlayerState RunState => runState;
    public PlayerState HitState => hitState;
    public PlayerState TalkState => talkState;
    public float WalkSpeed => walkSpeed;
    public float RunSpeed => runSpeed;
    public bool HasMoveInput => !(h == 0 && v == 0);
    public bool IsRunPressed => isRunPressed;
    public bool IsGettingCandy => didGetCandy;
    public bool HasContactNPC => npc != null;
    public bool IsRunGaugeEmpty => runGauge <= 0f;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        candy = GetComponent<Candy>();
        ResetAnimationBools();
        ChangeState(idleState);
        ResetPos();
    }

    private void Update()
    {
        currentState?.Update(this);
    }

    private void FixedUpdate()
    {
        currentState?.FixedUpdate(this);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("NPC"))
            npc = coll.gameObject;

        currentState?.OnCollisionEnter(this, coll);
    }

    private void OnCollisionExit(Collision coll)
    {
        if (coll.collider.CompareTag("NPC"))
            npc = null;

        currentState?.OnCollisionExit(this, coll);
    }

    private void OnDisable()
    {
        for (int i = 0; i < audioSource.Length; i++)
            audioSource[i].enabled = false;
    }

    public void ReadMoveInput()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    public void Move(float speed)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void Turn()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * turnSpeed, 0));
    }

    public void ChangeState(PlayerState nextState)
    {
        currentState = nextState;
        currentState.Enter(this);
    }

    public void SetAnimation(PlayerStateType stateType)
    {
        ResetAnimationBools();

        switch (stateType)
        {
            case PlayerStateType.Idle:
                ani.SetBool("idle", true);
                break;
            case PlayerStateType.Walk:
                ani.SetBool("walk", true);
                break;
            case PlayerStateType.Run:
                ani.SetBool("run", true);
                break;
            case PlayerStateType.Hit:
                ani.SetTrigger("hit");
                break;
            case PlayerStateType.Talk:
                ani.SetTrigger("talk");
                break;
        }
    }

    public void ChangeDidGetCandyState(bool value)
    {
        didGetCandy = value;
    }

    public bool IsRunKeyDown()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }

    public bool IsRunKeyUp()
    {
        return Input.GetKeyUp(KeyCode.LeftShift);
    }

    public bool IsTalkKeyDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    public void ChangeRunPressed(bool value)
    {
        isRunPressed = value;
    }

    public void ConsumeRunGauge()
    {
        ChangeRunGauge(-Time.deltaTime * runGaugeSpeed);
    }

    public void RecoverRunGauge()
    {
        ChangeRunGauge(Time.deltaTime * runGaugeSpeed);
    }

    public void NotifyRunGaugeChanged()
    {
        OnRunGaugeChanged?.Invoke(runGauge);
    }

    public bool IsAnimationFinished(string stateName)
    {
        AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(stateName) && stateInfo.normalizedTime >= 1f;
    }

    public void StartContactNPCTalk()
    {
        if (npc.name.Equals("SpecialNPC"))
            npc.GetComponent<SpecialNPC>().ChangeState(NPCStateType.Talk);
        else
            npc.GetComponent<NPC>().ChangeState(NPCStateType.Talk);
    }

    public void ApplyEnemyHit(EnemyBase enemy)
    {
        ChangeRunPressed(false);
        PlayHitAudio();

        if (enemy.TryReturnCandyToTake(out CandyType candyTypeToTake))
        {
            EnemyManager.Instance.ChangeGetCandyCnt(enemy.name);
            candy.ChangeCandyCnt(candyTypeToTake, -ReturnCandyTakeCount(enemy.EnemyType));
        }

        ChangeState(hitState);
    }

    public void PlayRunAudio()
    {
        audioSource[0].Play();
    }

    public void StopRunAudio()
    {
        audioSource[0].Stop();
    }

    private void ChangeRunGauge(float delta)
    {
        float beforeGauge = runGauge;
        runGauge = Mathf.Clamp01(runGauge + delta);

        if (!Mathf.Approximately(beforeGauge, runGauge))
            NotifyRunGaugeChanged();
    }

    private void ResetAnimationBools()
    {
        ani.SetBool("idle", false);
        ani.SetBool("walk", false);
        ani.SetBool("run", false);
    }

    private int ReturnCandyTakeCount(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Zombie:
                return 2;
            case EnemyType.Pierrot:
                return 5;
            case EnemyType.Chainsaw:
                return 7;
            default:
                Debug.LogWarning(enemyType);
                return 0;
        }
    }

    private void ResetPos()
    {
        transform.position = new Vector3(-18, 0, -12);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    private void PlayHitAudio()
    {
        audioSource[1].Play();
    }
}
