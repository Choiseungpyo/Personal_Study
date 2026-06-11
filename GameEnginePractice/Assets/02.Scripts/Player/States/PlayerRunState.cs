public class PlayerRunState : PlayerState
{
    public override void Enter(Player player)
    {
        player.SetAnimation(PlayerStateType.Run);
    }

    public override void Update(Player player)
    {
        ConsumeRunGauge(player);
        HandleRunInput(player);
        HandleTalkInput(player);

        if (!player.IsRunPressed || player.IsRunGaugeEmpty)
            player.ChangeState(player.WalkState);
    }

    public override void FixedUpdate(Player player)
    {
        if (player.IsGettingCandy)
            return;

        player.ReadMoveInput();

        if (!player.HasMoveInput)
        {
            player.ChangeState(player.IdleState);
            return;
        }

        player.Move(player.RunSpeed);
        player.Turn();
    }

    public override void OnCollisionEnter(Player player, UnityEngine.Collision coll)
    {
        TryHitEnemy(player, coll);
    }
}
