using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class PoolBase<TKey, TData> : MonoBehaviour
{
    private Dictionary<TKey, ObjectPool<GameObject>> pools = new Dictionary<TKey, ObjectPool<GameObject>>();
    private Dictionary<TKey, TData> dataStorage = new Dictionary<TKey, TData>();
    private Transform activeParent;

    public void Configure(TData[] datas, Transform parent)
    {
        activeParent = parent;
        pools.Clear();
        dataStorage.Clear();

        if (datas == null)
            return;

        for (int i = 0; i < datas.Length; i++)
        {
            TData data = datas[i];
            if (!IsValidData(data))
                continue;

            TKey key = ReturnKey(data);
            dataStorage[key] = data;
            pools[key] = CreatePool(data);
        }
    }

    public void PreloadAll()
    {
        foreach (KeyValuePair<TKey, TData> pair in dataStorage)
            Preload(pair.Key, ReturnDefaultCapacity(pair.Value));
    }

    public void Preload(TKey key, int count)
    {
        if (count <= 0)
            return;

        if (!pools.ContainsKey(key))
            return;

        ObjectPool<GameObject> pool = pools[key];
        List<GameObject> tempStorage = new List<GameObject>();

        for (int i = 0; i < count; i++)
            tempStorage.Add(pool.Get());

        for (int i = 0; i < tempStorage.Count; i++)
            pool.Release(tempStorage[i]);
    }

    protected GameObject GetFromPool(TKey key)
    {
        if (!pools.ContainsKey(key))
        {
            Debug.LogWarning(ReturnMissingPoolMessage(key));
            return null;
        }

        return pools[key].Get();
    }

    protected void ReleaseToPool(TKey key, GameObject obj)
    {
        if (obj == null)
            return;

        if (!pools.ContainsKey(key))
        {
            obj.SetActive(false);
            return;
        }

        pools[key].Release(obj);
    }

    protected bool TryGetData(TKey key, out TData data)
    {
        return dataStorage.TryGetValue(key, out data);
    }

    protected Transform ReturnActiveParent()
    {
        return activeParent;
    }

    protected virtual void OnGetObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    protected virtual void OnReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.SetParent(transform);
    }

    protected virtual void OnDestroyObject(GameObject obj)
    {
        Destroy(obj);
    }

    protected virtual string ReturnMissingPoolMessage(TKey key)
    {
        return "Pool missing key: " + key;
    }

    protected abstract bool IsValidData(TData data);
    protected abstract TKey ReturnKey(TData data);
    protected abstract GameObject CreateObject(TData data);
    protected abstract int ReturnDefaultCapacity(TData data);
    protected abstract int ReturnMaxSize(TData data);

    private ObjectPool<GameObject> CreatePool(TData data)
    {
        return new ObjectPool<GameObject>(
            () => CreateObject(data),
            OnGetObject,
            OnReleaseObject,
            OnDestroyObject,
            false,
            ReturnDefaultCapacity(data),
            ReturnMaxSize(data));
    }
}
