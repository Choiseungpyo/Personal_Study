public class SpecialNPCTalkState : SpecialNPCState
{
    public override void Enter(SpecialNPC specialNPC)
    {
        specialNPC.PlayTalkAnimation();
    }

    public override void Update(SpecialNPC specialNPC)
    {
        LookAtPlayer(specialNPC);

        if (!specialNPC.CanStartPuzzleAfterTalk())
            return;

        specialNPC.StartPuzzle();
    }
}
