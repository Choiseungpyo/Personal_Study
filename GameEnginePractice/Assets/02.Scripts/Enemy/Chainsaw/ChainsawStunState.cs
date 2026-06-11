public class ChainsawStunState : EnemyState<Chainsaw>
{
    public override void Enter(Chainsaw chainsaw)
    {
        chainsaw.Ani.SetBool("idle", false);
        chainsaw.Ani.SetBool("stun", true);
        chainsaw.Ani.SetBool("attack", false);
        chainsaw.Ani.SetTrigger("dead");
    }
}
