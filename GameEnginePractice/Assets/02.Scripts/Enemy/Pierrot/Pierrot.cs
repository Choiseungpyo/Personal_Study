using UnityEngine;

public class Pierrot : EnemyBase
{
    private EnemyState<Pierrot> idleState = new PierrotIdleState();
    private EnemyState<Pierrot> scareState = new PierrotScareState();

    private EnemyState<Pierrot> currentState;

    public EnemyState<Pierrot> IdleState => idleState;

    protected override void Awake()
    {
        ChangeEnemyType(EnemyType.Pierrot);
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

    public override void ResetEnemyForSpawn()
    {
        base.ResetEnemyForSpawn();
        ChangeState(scareState);
    }

    public void ChangeState(EnemyState<Pierrot> nextState)
    {
        currentState = nextState;
        currentState.Enter(this);
    }
}
