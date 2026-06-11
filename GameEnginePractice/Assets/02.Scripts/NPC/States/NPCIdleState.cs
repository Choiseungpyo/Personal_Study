public class NPCIdleState : NPCState
{
    public override void Update(NPC npc)
    {
        LookAtPlayer(npc);
    }
}
