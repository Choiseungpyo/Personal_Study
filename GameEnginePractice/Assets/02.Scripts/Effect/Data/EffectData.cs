using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "EffectData", menuName = "Game/Effect Data")]
public class EffectData : ScriptableObject
{
    [FormerlySerializedAs("Type")]
    [SerializeField] private EffectType type;
    [FormerlySerializedAs("Prefab")]
    [SerializeField] private GameObject prefab;
    [FormerlySerializedAs("DefaultDuration")]
    [SerializeField] private float defaultDuration = 1f;
    [FormerlySerializedAs("DefaultCapacity")]
    [SerializeField] private int defaultCapacity = 3;
    [FormerlySerializedAs("MaxSize")]
    [SerializeField] private int maxSize = 20;

    public EffectType Type => type;
    public GameObject Prefab => prefab;
    public float DefaultDuration => defaultDuration;
    public int DefaultCapacity => defaultCapacity;
    public int MaxSize => maxSize;
}
