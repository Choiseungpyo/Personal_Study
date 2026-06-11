using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private EnemyData[] EnemyDatas;
    [SerializeField] private GameObject Player_Obj;
    [SerializeField] private Transform[] EnemySpawnPoints = new Transform[3];

    private List<GameObject> enemys = new List<GameObject>();
    private List<int> enemyToAppear = new List<int>();
    private float enemySpawnTime = 10f;
    private int[] getCandyCnt = new int[3];
    private GameManager gameManager;
    private EnemyPool enemyPool;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        enemyPool = GetComponent<EnemyPool>();
        if (enemyPool == null)
            enemyPool = gameObject.AddComponent<EnemyPool>();

        enemyPool.Configure(EnemyDatas, transform);
        enemyPool.PreloadAll();
        ResetGetCandyCnt();
        enemys.Clear();
        enemyToAppear.Clear();
        StartCoroutine(MakeEnemys());
    }

    private GameObject MakeObj(EnemyData data, Vector3 pos)
    {
        return enemyPool.Spawn(data.Type, pos);
    }

    private void AddList(string type, GameObject obj)
    {
        if (obj == null)
            return;

        switch(type)
        {
            case "enemys":
                enemys.Add(obj);
                break;
            default:
                Debug.LogWarning(type);
                break;
        }
    }

    private IEnumerator MakeEnemys()
    {
        GameObject tmp = null;
        int randEnemyIndex = 0;
        Vector3 randPos = Vector3.zero;
        EnemyData data = null;

        while(true)
        {
            yield return new WaitForSeconds(enemySpawnTime);

            if (!gameManager.CanSpawnEnemy())
                continue;

            if (enemys.Count > 3)
                continue;

            randEnemyIndex = ReturnRandEnemyIndex();
            enemyToAppear.Add(randEnemyIndex);
            data = ReturnEnemyData(randEnemyIndex);

            if (data == null)
                continue;

            randPos = ReturnRandPos();

            if (data.Type == EnemyType.Pierrot)
            {
                StartCoroutine(ManagePierrotAppearance(data, Player_Obj.transform.position));
                continue;
            }

            StartCoroutine(MakeAppearanceEffect(data, randPos));
            tmp = MakeObj(data, randPos);
            AddList("enemys", tmp);
        }
    }

    private void RemoveListElement(string type, GameObject obj)
    {
        switch (type)
        {
            case "enemy":
                enemys.Remove(obj);
                break;
            default:
                Debug.LogWarning("type : " + type);
                break;
        }
    }

    private IEnumerator ManagePierrotAppearance(EnemyData data, Vector3 pos)
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.4f - 0.1f * i);
            if (data.AreaEffectType == EffectType.None)
                continue;

            float duration = 0.4f - 0.1f * i;
            Vector3 scale = Vector3.one;
            if (i == 1)
                scale = Vector3.one * 0.3f;
            else if (i == 2)
                scale = Vector3.one * 0.5f;

            EffectManager.Instance.Play(data.AreaEffectType, pos, scale, duration);
            yield return new WaitForSeconds(duration);
        }

        if (!gameManager.CanSpawnEnemy())
            yield break;

        StartCoroutine(MakeAppearanceEffect(data, pos));
        GameObject tmpObj = MakeObj(data, pos);
        AddList("enemys", tmpObj);
    }

    public void RemoveObj(string type, GameObject obj)
    {
        RemoveListElement(type, obj);
        enemyPool.Release(obj);
    }

    private Vector3 ReturnRandPos()
    {
        int randIndex = Random.Range(0, EnemySpawnPoints.Length);
        return EnemySpawnPoints[randIndex].transform.position;
    }

    private int ReturnRandEnemyIndex()
    {
        int randIndex = 0;
        int enemyCount = EnemyDatas == null ? 0 : EnemyDatas.Length;

        if (enemyCount <= 0)
            return randIndex;

        if (enemyToAppear.Count < enemyCount)
            randIndex = enemyToAppear.Count;
        else
            randIndex = Random.Range(0, enemyCount);

        return randIndex;
    }

    private EnemyData ReturnEnemyData(int index)
    {
        if (EnemyDatas == null)
            return null;

        if (index < 0 || index >= EnemyDatas.Length)
            return null;

        return EnemyDatas[index];
    }

    private IEnumerator MakeAppearanceEffect(EnemyData data, Vector3 pos)
    {
        if (data.AppearanceEffectType == EffectType.None)
            yield break;

        EffectManager.Instance.Play(data.AppearanceEffectType, pos);
        yield return null;
    }

    public void ReleaseAllEnemies()
    {
        for (int i = enemys.Count - 1; i >= 0; i--)
        {
            if (enemys[i] != null)
                enemyPool.Release(enemys[i]);
        }

        enemys.Clear();
    }

    private void ResetGetCandyCnt()
    {
        for (int i = 0; i < getCandyCnt.Length; i++)
            getCandyCnt[i] = 0;
    }

    public void ChangeGetCandyCnt(string EnemyName)
    {
        if(EnemyName.Contains("Zombie"))
            getCandyCnt[0]++;
        else if(EnemyName.Contains("Pierrot"))
            getCandyCnt[1]++;
        else if (EnemyName.Contains("Chainsaw"))
            getCandyCnt[2]++;
    }

    public int ReturnGetCandyCnt(int index)
    {
        return getCandyCnt[index];
    }
}
