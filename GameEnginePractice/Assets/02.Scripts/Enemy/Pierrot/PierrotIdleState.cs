using UnityEngine;

public class PierrotIdleState : EnemyState<Pierrot>
{
    private float elapsedTime;

    public override void Enter(Pierrot pierrot)
    {
        elapsedTime = 0f;
        pierrot.Ani.SetBool("idle", true);
    }

    public override void Update(Pierrot pierrot)
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1f)
            pierrot.ReturnToPool();
    }
}
