using UnityEngine;

public class NPC : MonoBehaviour
{
    private NPCState idleState = new NPCIdleState();
    private NPCState talkState = new NPCTalkState();
    private NPCState endState = new NPCEndState();
    private NPCState currentState;

    private CandyType candyToGive = CandyType.Hard;
    private int posIndex = 0;
    private int candyCntToGive = 0;
    private Animator ani;
    private Transform playerTransform;
    private Player player;
    private Candy playerCandy;
    private NPCUIManager npcUIManager;

    public NPCState IdleState => idleState;
    public NPCState TalkState => talkState;
    public NPCState EndState => endState;

    private void Awake()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        ani = GetComponent<Animator>();
        npcUIManager = GetComponent<NPCUIManager>();
        playerTransform = playerObj.transform;
        playerCandy = playerObj.GetComponent<Candy>();
        player = playerObj.GetComponent<Player>();
        ChangeState(idleState);
    }

    public void ResetNPCForSpawn(int posIndex, Avatar avatar)
    {
        ChangePosIndex(posIndex);
        if (avatar != null)
            ani.avatar = avatar;

        ani.ResetTrigger("talk");
        ani.ResetTrigger("end");
        ani.Play("Idle", 0, 0f);
        candyToGive = playerCandy.ReturnRandomCandy();
        candyCntToGive = Random.Range(1, 4);
        npcUIManager.SetCandyData(candyToGive, candyCntToGive);
        ChangeState(idleState);
    }

    private void Update()
    {
        currentState?.Update(this);
    }

    public void ChangeState(NPCState nextState)
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

    public void ChangePosIndex(int value)
    {
        posIndex = value;
    }

    public void PlayTalkAnimation()
    {
        ani.SetTrigger("talk");
    }

    public void PlayEndAnimation()
    {
        ani.SetTrigger("end");
    }

    public bool IsAnimationPlaying(string stateName)
    {
        return ani.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    public bool IsAnimationFinished(string stateName)
    {
        AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0);
        return stateInfo.IsName(stateName) && stateInfo.normalizedTime >= 1f;
    }

    public void ReleasePlayerFromTalk()
    {
        player.ChangeDidGetCandyState(false);
    }

    public void GiveCandyAndRemove()
    {
        playerCandy.ChangeCandyCnt(candyToGive, candyCntToGive);
        NPCManager.Instance.DeactivateNPCIndexState(posIndex);
        NPCManager.Instance.MakeTalkEffect(transform.position + new Vector3(0, 1.5f, 0), "GetCandy");
        NPCManager.Instance.ReleaseNPC(gameObject);
    }

    public void LookAtPlayer()
    {
        transform.LookAt(playerTransform);
    }
}
