using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Game/Enemy Data")]
public class EnemyData : ScriptableObject
{
    [FormerlySerializedAs("Type")]
    [SerializeField] private EnemyType type;
    [FormerlySerializedAs("EnemyName")]
    [SerializeField] private string enemyName;
    [FormerlySerializedAs("EnemyPrefab")]
    [SerializeField] private GameObject enemyPrefab;
    [FormerlySerializedAs("AppearanceEffectType")]
    [SerializeField] private EffectType appearanceEffectType;
    [FormerlySerializedAs("AreaEffectType")]
    [SerializeField] private EffectType areaEffectType;
    [FormerlySerializedAs("DefaultCapacity")]
    [SerializeField] private int defaultCapacity = 3;
    [FormerlySerializedAs("MaxSize")]
    [SerializeField] private int maxSize = 10;

    public EnemyType Type => type;
    public string EnemyName => enemyName;
    public GameObject EnemyPrefab => enemyPrefab;
    public EffectType AppearanceEffectType => appearanceEffectType;
    public EffectType AreaEffectType => areaEffectType;
    public int DefaultCapacity => defaultCapacity;
    public int MaxSize => maxSize;
}
