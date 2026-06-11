using System.Collections;
using UnityEngine;

public class EffectPool : PoolBase<EffectType, EffectData>
{
    public GameObject Play(EffectType type, Vector3 position)
    {
        return Play(type, position, Quaternion.identity, Vector3.one, ReturnDefaultDuration(type));
    }

    public GameObject Play(EffectType type, Vector3 position, Vector3 scale, float duration)
    {
        return Play(type, position, Quaternion.identity, scale, duration);
    }

    public GameObject Play(EffectType type, Vector3 position, Quaternion rotation, Vector3 scale, float duration)
    {
        if (type == EffectType.None)
            return null;

        GameObject obj = GetFromPool(type);
        if (obj == null)
            return null;

        obj.transform.SetParent(ReturnActiveParent());
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.transform.localScale = scale;
        StartCoroutine(ReleaseAfter(type, obj, duration));
        return obj;
    }

    public float ReturnDefaultDuration(EffectType type)
    {
        EffectData data = null;
        if (!TryGetData(type, out data))
            return 1f;

        return data.DefaultDuration;
    }

    protected override bool IsValidData(EffectData data)
    {
        return data != null && data.Prefab != null && data.Type != EffectType.None;
    }

    protected override EffectType ReturnKey(EffectData data)
    {
        return data.Type;
    }

    protected override GameObject CreateObject(EffectData data)
    {
        return Instantiate(data.Prefab, ReturnActiveParent());
    }

    protected override int ReturnDefaultCapacity(EffectData data)
    {
        return data.DefaultCapacity;
    }

    protected override int ReturnMaxSize(EffectData data)
    {
        return data.MaxSize;
    }

    protected override void OnReleaseObject(GameObject obj)
    {
        base.OnReleaseObject(obj);
        obj.transform.localScale = Vector3.one;
    }

    protected override string ReturnMissingPoolMessage(EffectType key)
    {
        return "EffectPool missing type: " + key;
    }

    private IEnumerator ReleaseAfter(EffectType type, GameObject obj, float duration)
    {
        yield return new WaitForSeconds(duration);

        if (obj != null && obj.activeSelf)
            ReleaseToPool(type, obj);
    }
}
