public class NPCTalkState : NPCState
{
    public override void Enter(NPC npc)
    {
        npc.PlayTalkAnimation();
    }

    public override void Update(NPC npc)
    {
        LookAtPlayer(npc);

        if (!npc.IsAnimationFinished("wave"))
            return;

        npc.ReleasePlayerFromTalk();
        npc.ChangeState(npc.EndState);
    }
}
