public class PierrotScareState : EnemyState<Pierrot>
{
    public override void Enter(Pierrot pierrot)
    {
        pierrot.Ani.SetBool("idle", false);

        if (pierrot.PlayerObj != null)
            pierrot.transform.LookAt(pierrot.PlayerObj.transform);
    }

    public override void Update(Pierrot pierrot)
    {
        if (!pierrot.Ani.GetCurrentAnimatorStateInfo(0).IsName("Scare"))
            return;

        if (pierrot.Ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            pierrot.ChangeState(pierrot.IdleState);
    }
}
