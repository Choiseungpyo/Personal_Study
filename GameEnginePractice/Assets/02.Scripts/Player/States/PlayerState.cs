using UnityEngine;

public abstract class PlayerState : EntityState<Player>
{
    protected void RecoverRunGauge(Player player)
    {
        player.RecoverRunGauge();
    }

    protected void ConsumeRunGauge(Player player)
    {
        player.ConsumeRunGauge();

        if (player.IsRunGaugeEmpty)
            player.ChangeRunPressed(false);
    }

    protected void HandleRunInput(Player player)
    {
        if (player.IsGettingCandy)
            return;

        if (player.IsRunGaugeEmpty)
        {
            player.ChangeRunPressed(false);
            return;
        }

        if (player.IsRunKeyDown())
        {
            player.PlayRunAudio();
            player.ChangeRunPressed(true);
        }
        else if (player.IsRunKeyUp())
        {
            player.StopRunAudio();
            player.ChangeRunPressed(false);
        }
    }

    protected void HandleTalkInput(Player player)
    {
        if (!player.HasContactNPC)
            return;

        if (!player.IsTalkKeyDown() || player.IsGettingCandy)
            return;

        player.ChangeDidGetCandyState(true);
        player.ChangeRunPressed(false);
        player.StopRunAudio();
        player.ChangeState(player.TalkState);
        player.StartContactNPCTalk();
    }

    protected void ChangeMoveState(Player player)
    {
        if (!player.HasMoveInput)
        {
            player.ChangeState(player.IdleState);
            return;
        }

        if (player.IsRunPressed && !player.IsRunGaugeEmpty)
            player.ChangeState(player.RunState);
        else
            player.ChangeState(player.WalkState);
    }

    protected bool TryHitEnemy(Player player, Collision coll)
    {
        EnemyBase enemy = coll.collider.GetComponentInParent<EnemyBase>();
        if (enemy == null)
            return false;

        player.ApplyEnemyHit(enemy);
        return true;
    }
}
