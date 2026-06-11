public class NPCEndState : NPCState
{
    public override void Enter(NPC npc)
    {
        npc.GiveCandyAndRemove();
    }
}
