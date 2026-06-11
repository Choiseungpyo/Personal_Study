public class PlayerWalkState : PlayerState
{
    public override void Enter(Player player)
    {
        player.SetAnimation(PlayerStateType.Walk);
    }

    public override void Update(Player player)
    {
        RecoverRunGauge(player);
        HandleRunInput(player);
        HandleTalkInput(player);
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

        player.Move(player.WalkSpeed);
        player.Turn();
        ChangeMoveState(player);
    }

    public override void OnCollisionEnter(Player player, UnityEngine.Collision coll)
    {
        TryHitEnemy(player, coll);
    }
}
