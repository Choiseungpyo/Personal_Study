public abstract class NPCState : EntityState<NPC>
{
    protected void LookAtPlayer(NPC npc)
    {
        npc.LookAtPlayer();
    }
}
