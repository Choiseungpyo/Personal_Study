public class PlayerHitState : PlayerState
{
    public override void Enter(Player player)
    {
        player.SetAnimation(PlayerStateType.Hit);
    }

    public override void Update(Player player)
    {
        RecoverRunGauge(player);

        if (player.IsAnimationFinished("Hit"))
        {
            player.StopRunAudio();
            player.ChangeState(player.IdleState);
        }
    }
}
