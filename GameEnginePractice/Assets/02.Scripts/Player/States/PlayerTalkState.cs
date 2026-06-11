public class PlayerTalkState : PlayerState
{
    public override void Enter(Player player)
    {
        player.SetAnimation(PlayerStateType.Talk);
    }

    public override void Update(Player player)
    {
        RecoverRunGauge(player);

        if (!player.IsAnimationFinished("Talk"))
            return;

        player.ChangeDidGetCandyState(false);
        player.ChangeState(player.IdleState);
    }
}
