using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;

    protected CandyType candyToTake = CandyType.Hard;
    protected bool hasCandyToTake = false;
    protected GameObject playerObj;
    protected Player player;
    protected EnemyManager enemyManager;
    protected GameManager gameManager;
    protected Animator ani;

    public EnemyType EnemyType => enemyType;
    public GameObject PlayerObj => playerObj;
    public Animator Ani => ani;

    protected virtual void Awake()
    {
        ani = GetComponent<Animator>();
        playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
            player = playerObj.GetComponent<Player>();

        enemyManager = EnemyManager.Instance;
        gameManager = GameManager.Instance;
    }

    public virtual void ResetEnemyForSpawn()
    {
        StopAllCoroutines();
        RefreshCandyToTake();
    }

    protected void ChangeEnemyType(EnemyType value)
    {
        enemyType = value;
    }

    protected bool CanAct()
    {
        return gameManager == null || gameManager.CanEnemiesMove();
    }

    public void ReturnToPool()
    {
        if (enemyManager == null)
        {
            gameObject.SetActive(false);
            return;
        }

        enemyManager.RemoveObj("enemy", gameObject);
    }

    private void RefreshCandyToTake()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj == null)
            return;

        hasCandyToTake = playerObj.GetComponent<Candy>().TryReturnRandomOwnedCandy(out candyToTake);
    }

    public bool TryReturnCandyToTake(out CandyType candyType)
    {
        if (!hasCandyToTake)
            RefreshCandyToTake();

        candyType = candyToTake;
        return hasCandyToTake;
    }

    public CandyType ReturnCandyTypeToTake()
    {
        if (!hasCandyToTake)
            RefreshCandyToTake();

        return candyToTake;
    }
}
