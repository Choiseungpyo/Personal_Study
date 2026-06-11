public class SpecialNPCIdleState : SpecialNPCState
{
    public override void Update(SpecialNPC specialNPC)
    {
        LookAtPlayer(specialNPC);
    }
}
