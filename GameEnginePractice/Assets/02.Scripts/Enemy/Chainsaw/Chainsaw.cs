using UnityEngine;
using UnityEngine.Serialization;

public class Chainsaw : EnemyBase
{
    private EnemyState<Chainsaw> findState = new ChainsawFindState();
    private EnemyState<Chainsaw> chaseState = new ChainsawChaseState();
    private EnemyState<Chainsaw> attackState = new ChainsawAttackState();
    private EnemyState<Chainsaw> stunState = new ChainsawStunState();

    private EnemyState<Chainsaw> currentState;

    [FormerlySerializedAs("Weapon")]
    [SerializeField] private GameObject weapon;

    [SerializeField] private float chaseSpeed = 5f;
    [SerializeField] private float turnSpeed = 3f;
    [SerializeField] private int playerDetectDist = 20;
    [SerializeField] private float findMoveDist = 7f;
    [SerializeField] private float findMoveSpeed = 2.5f;

    private bool canMove = true;
    private Vector3 findStartPos;
    private Vector3[] findDirs = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
    private int[] reverseFindDirIndex = { 1, 0, 3, 2 };
    private int currentFindDirIndex = 0;

    public GameObject Weapon => weapon;
    public float ChaseSpeed => chaseSpeed;
    public float TurnSpeed => turnSpeed;
    public int PlayerDetectDist => playerDetectDist;
    public float FindMoveDist => findMoveDist;
    public float FindMoveSpeed => findMoveSpeed;
    public bool CanMove { get => canMove; set => canMove = value; }
    public Vector3 FindStartPos { get => findStartPos; set => findStartPos = value; }
    public Vector3[] FindDirs => findDirs;
    public int[] ReverseFindDirIndex => reverseFindDirIndex;
    public int CurrentFindDirIndex { get => currentFindDirIndex; set => currentFindDirIndex = value; }
    public EnemyState<Chainsaw> FindState => findState;
    public EnemyState<Chainsaw> ChaseState => chaseState;
    public EnemyState<Chainsaw> AttackState => attackState;
    public EnemyState<Chainsaw> StunState => stunState;

    protected override void Awake()
    {
        ChangeEnemyType(EnemyType.Chainsaw);
        base.Awake();
    }

    private void Start()
    {
        ResetEnemyForSpawn();
    }

    private void Update()
    {
        if (!CanAct())
            return;

        currentState?.Update(this);
    }

    private void OnCollisionEnter(Collision coll)
    {
        currentState?.OnCollisionEnter(this, coll);
    }

    private void OnCollisionExit(Collision coll)
    {
        currentState?.OnCollisionExit(this, coll);
    }

    public override void ResetEnemyForSpawn()
    {
        base.ResetEnemyForSpawn();
        canMove = true;
        currentFindDirIndex = 0;
        findStartPos = transform.position;

        BoxCollider weaponCollider = weapon == null ? null : weapon.GetComponent<BoxCollider>();
        if (weaponCollider != null)
            weaponCollider.enabled = true;

        ChangeState(findState);
    }

    public void ChangeState(EnemyState<Chainsaw> nextState)
    {
        currentState = nextState;
        currentState.Enter(this);
    }

    public void RemoveChainsaw()
    {
        ReturnToPool();
    }
}
