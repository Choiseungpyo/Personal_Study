using UnityEngine;

public class SpecialNPC : MonoBehaviour
{
    private SpecialNPCState idleState = new SpecialNPCIdleState();
    private SpecialNPCState talkState = new SpecialNPCTalkState();
    private SpecialNPCState endState = new SpecialNPCEndState();
    private SpecialNPCState currentState;

    private Transform playerTransform;
    private Animator ani;
    private PuzzleUIManager puzzleUIManager;
    private NPCManager npcManager;
    private Player player;
    private bool talkAnimationEnded = false;
    private bool puzzleStarted = false;

    public SpecialNPCState IdleState => idleState;
    public SpecialNPCState TalkState => talkState;
    public SpecialNPCState EndState => endState;

    private void Awake()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        playerTransform = playerObj.transform;
        player = playerObj.GetComponent<Player>();
        puzzleUIManager = PuzzleUIManager.Instance;
        npcManager = NPCManager.Instance;
        ani = GetComponent<Animator>();
        ChangeState(idleState);
    }

    public void ResetSpecialNPCForSpawn()
    {
        ani.ResetTrigger("talk");
        ani.ResetTrigger("end");
        ani.Play("Idle", 0, 0f);
        talkAnimationEnded = false;
        puzzleStarted = false;
        ChangeState(idleState);
    }

    private void Update()
    {
        currentState?.Update(this);
    }

    public void ChangeState(SpecialNPCState nextState)
    {
        currentState = nextState;
        currentState.Enter(this);
    }

    public void ChangeState(NPCStateType stateType)
    {
        switch (stateType)
        {
            case NPCStateType.Idle:
                ChangeState(idleState);
                break;
            case NPCStateType.Talk:
                ChangeState(talkState);
                break;
            case NPCStateType.End:
                ChangeState(endState);
                break;
        }
    }

    public void PlayTalkAnimation()
    {
        talkAnimationEnded = false;
        puzzleStarted = false;
        ani.SetTrigger("talk");
    }

    public void NotifyTalkAnimationEnded()
    {
        talkAnimationEnded = true;
    }

    public bool CanStartPuzzleAfterTalk()
    {
        if (puzzleStarted)
            return false;

        if (!talkAnimationEnded)
            return false;

        return player == null || player.IsAnimationFinished("Talk");
    }

    public void StartPuzzle()
    {
        if (puzzleStarted)
            return;

        puzzleStarted = true;
        puzzleUIManager.ActivatePuzzleUI();
        if (player != null)
            player.ChangeDidGetCandyState(false);

        ChangeState(idleState);
    }

    public void FinishPuzzleAndRemove()
    {
        npcManager.ChangeSpecialNPCISSpawnState(false);
        npcManager.MakeTalkEffect(transform.position + new Vector3(0, 1.5f, 0), puzzleUIManager.ReturnGameResult());
        npcManager.ReleaseSpecialNPC(gameObject);
    }

    public void LookAtPlayer()
    {
        transform.LookAt(playerTransform);
    }
}
