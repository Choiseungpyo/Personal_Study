public class SpecialNPCEndState : SpecialNPCState
{
    public override void Enter(SpecialNPC specialNPC)
    {
        specialNPC.FinishPuzzleAndRemove();
    }
}
