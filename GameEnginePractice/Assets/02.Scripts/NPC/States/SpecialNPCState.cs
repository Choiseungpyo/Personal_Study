public abstract class SpecialNPCState : EntityState<SpecialNPC>
{
    protected void LookAtPlayer(SpecialNPC specialNPC)
    {
        specialNPC.LookAtPlayer();
    }
}
