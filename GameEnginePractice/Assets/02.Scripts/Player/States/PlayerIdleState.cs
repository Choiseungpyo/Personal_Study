public class PlayerIdleState : PlayerState
{
    public override void Enter(Player player)
    {
        player.SetAnimation(PlayerStateType.Idle);
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
        player.Turn();

        if (player.HasMoveInput)
            ChangeMoveState(player);
    }

    public override void OnCollisionEnter(Player player, UnityEngine.Collision coll)
    {
        TryHitEnemy(player, coll);
    }
}
