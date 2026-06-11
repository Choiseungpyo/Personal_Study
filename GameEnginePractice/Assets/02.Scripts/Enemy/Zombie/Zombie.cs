using UnityEngine;

public class Zombie : EnemyBase
{
    private EnemyState<Zombie> idleState = new ZombieIdleState();
    private EnemyState<Zombie> crawlState = new ZombieCrawlState();
    private EnemyState<Zombie> removingState = new ZombieRemovingState();

    private EnemyState<Zombie> currentState;

    [SerializeField] private float crawlSpeed = 10f;
    [SerializeField] private float crawlDist = 15f;
    [SerializeField] private int goalCntToCrawl = 3;

    public float CrawlSpeed => crawlSpeed;
    public float CrawlDist => crawlDist;
    public int GoalCntToCrawl => goalCntToCrawl;
    public EnemyState<Zombie> IdleState => idleState;
    public EnemyState<Zombie> CrawlState => crawlState;
    public EnemyState<Zombie> RemovingState => removingState;

    protected override void Awake()
    {
        ChangeEnemyType(EnemyType.Zombie);
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

    public override void ResetEnemyForSpawn()
    {
        base.ResetEnemyForSpawn();
        ChangeState(crawlState);
    }

    public void ChangeState(EnemyState<Zombie> nextState)
    {
        currentState = nextState;
        currentState.Enter(this);
    }
}
