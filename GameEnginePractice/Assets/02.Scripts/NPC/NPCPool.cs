using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class NPCPool : MonoBehaviour
{
    private ObjectPool<GameObject> npcPool;
    private ObjectPool<GameObject> specialNPCPool;
    private GameObject npcPrefab;
    private GameObject specialNPCPrefab;
    private Transform activeParent;
    private int npcPreloadCount;
    private int specialNPCPreloadCount;

    public void Configure(GameObject npcPrefab, GameObject specialNPCPrefab, Transform parent, int npcCapacity, int specialNPCCapacity)
    {
        this.npcPrefab = npcPrefab;
        this.specialNPCPrefab = specialNPCPrefab;
        activeParent = parent;
        npcPreloadCount = Mathf.Max(0, npcCapacity);
        specialNPCPreloadCount = Mathf.Max(0, specialNPCCapacity);

        npcPool = CreatePool(this.npcPrefab, npcPreloadCount, Mathf.Max(1, npcPreloadCount));
        specialNPCPool = CreatePool(this.specialNPCPrefab, specialNPCPreloadCount, Mathf.Max(1, specialNPCPreloadCount));
    }

    public void PreloadAll()
    {
        Preload(npcPool, npcPreloadCount);
        Preload(specialNPCPool, specialNPCPreloadCount);
    }

    public GameObject SpawnNPC(Vector3 position, Avatar avatar, int posIndex)
    {
        if (npcPool == null)
            return null;

        GameObject obj = npcPool.Get();
        obj.transform.SetParent(activeParent);
        obj.transform.SetPositionAndRotation(position, Quaternion.identity);
        obj.name = "NPC";

        NPC npc = obj.GetComponent<NPC>();
        if (npc != null)
            npc.ResetNPCForSpawn(posIndex, avatar);

        return obj;
    }

    public GameObject SpawnSpecialNPC(Vector3 position)
    {
        if (specialNPCPool == null)
            return null;

        GameObject obj = specialNPCPool.Get();
        obj.transform.SetParent(activeParent);
        obj.transform.SetPositionAndRotation(position, Quaternion.identity);
        obj.name = "SpecialNPC";

        SpecialNPC specialNPC = obj.GetComponent<SpecialNPC>();
        if (specialNPC != null)
            specialNPC.ResetSpecialNPCForSpawn();

        return obj;
    }

    public void ReleaseNPC(GameObject obj)
    {
        Release(npcPool, obj);
    }

    public void ReleaseSpecialNPC(GameObject obj)
    {
        Release(specialNPCPool, obj);
    }

    private ObjectPool<GameObject> CreatePool(GameObject prefab, int defaultCapacity, int maxSize)
    {
        if (prefab == null)
            return null;

        return new ObjectPool<GameObject>(
            () => Instantiate(prefab, activeParent),
            obj => obj.SetActive(true),
            obj =>
            {
                obj.SetActive(false);
                obj.transform.SetParent(transform);
            },
            Destroy,
            false,
            defaultCapacity,
            maxSize);
    }

    private void Preload(ObjectPool<GameObject> pool, int count)
    {
        if (pool == null || count <= 0)
            return;

        List<GameObject> tempStorage = new List<GameObject>();
        for (int i = 0; i < count; i++)
            tempStorage.Add(pool.Get());

        for (int i = 0; i < tempStorage.Count; i++)
            pool.Release(tempStorage[i]);
    }

    private void Release(ObjectPool<GameObject> pool, GameObject obj)
    {
        if (obj == null)
            return;

        if (pool == null)
        {
            obj.SetActive(false);
            return;
        }

        pool.Release(obj);
    }
}
