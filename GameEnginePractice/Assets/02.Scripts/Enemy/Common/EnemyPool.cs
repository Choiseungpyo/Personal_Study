using UnityEngine;

public class EnemyPool : PoolBase<EnemyType, EnemyData>
{
    public GameObject Spawn(EnemyType type, Vector3 pos)
    {
        GameObject obj = GetFromPool(type);
        if (obj == null)
            return null;

        obj.transform.SetParent(ReturnActiveParent());
        obj.transform.position = pos;
        obj.transform.rotation = Quaternion.identity;
        obj.name = ReturnEnemyName(type);

        EnemyBase enemy = obj.GetComponent<EnemyBase>();
        if (enemy != null)
            enemy.ResetEnemyForSpawn();

        EnemyUIManager enemyUIManager = obj.GetComponent<EnemyUIManager>();
        if (enemyUIManager != null)
            enemyUIManager.Refresh();

        return obj;
    }

    public void Release(GameObject obj)
    {
        if (obj == null)
            return;

        EnemyBase enemy = obj.GetComponent<EnemyBase>();
        if (enemy == null)
        {
            obj.SetActive(false);
            return;
        }

        ReleaseToPool(enemy.EnemyType, obj);
    }

    protected override bool IsValidData(EnemyData data)
    {
        return data != null && data.EnemyPrefab != null;
    }

    protected override EnemyType ReturnKey(EnemyData data)
    {
        return data.Type;
    }

    protected override GameObject CreateObject(EnemyData data)
    {
        return Instantiate(data.EnemyPrefab, ReturnActiveParent());
    }

    protected override int ReturnDefaultCapacity(EnemyData data)
    {
        return data.DefaultCapacity;
    }

    protected override int ReturnMaxSize(EnemyData data)
    {
        return data.MaxSize;
    }

    protected override string ReturnMissingPoolMessage(EnemyType key)
    {
        return "EnemyPool missing type: " + key;
    }

    private string ReturnEnemyName(EnemyType type)
    {
        EnemyData data = null;
        if (TryGetData(type, out data) && !string.IsNullOrEmpty(data.EnemyName))
            return data.EnemyName;

        return type.ToString();
    }
}
