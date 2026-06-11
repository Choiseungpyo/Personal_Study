using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    [SerializeField] private EffectData[] EffectDatas;

    private EffectPool effectPool;

    protected override void Awake()
    {
        base.Awake();
        if (!IsSingletonInstance())
            return;

        effectPool = GetComponent<EffectPool>();
        if (effectPool == null)
            effectPool = gameObject.AddComponent<EffectPool>();

        effectPool.Configure(EffectDatas, transform);
    }

    private void Start()
    {
        effectPool.PreloadAll();
    }

    public GameObject Play(EffectType type, Vector3 position)
    {
        return effectPool.Play(type, position);
    }

    public GameObject Play(EffectType type, Vector3 position, Vector3 scale, float duration)
    {
        return effectPool.Play(type, position, scale, duration);
    }
}
