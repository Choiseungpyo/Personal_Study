using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCManager : Singleton<NPCManager>
{
    [SerializeField] private GameObject NPCPrefab;
    [SerializeField] private GameObject SpecialNPCPrefab;
    [SerializeField] private Avatar[] NPCAvatars = new Avatar[3];

    // À§Ä¡
    [SerializeField] private Transform[] NPCSpawnPoints = new Transform[4];
    [SerializeField] private Transform[] SpecialNPCSpawnPoints = new Transform[4];
    
    // ÀÌÆåÆ®
    [SerializeField] private EffectType TalkEffectType;
    [SerializeField] private EffectType AppearanceEffectType;


    private int spawnTime = 10;
    private int specialNPCSpawnTime = 30;

    private bool[] usingNPCIndex = new bool[4];
    private bool SpecialNPCISSpawn = false;

    private AudioSource audioSource;
    private NPCPool npcPool;

    protected override void Awake()
    {
        base.Awake();
        if (!IsSingletonInstance())
            return;

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        npcPool = GetComponent<NPCPool>();
        if (npcPool == null)
            npcPool = gameObject.AddComponent<NPCPool>();

        npcPool.Configure(NPCPrefab, SpecialNPCPrefab, transform, NPCSpawnPoints.Length, 1);
        npcPool.PreloadAll();

        ChangeSpecialNPCISSpawnState(false);
        InitUsingNpcIndex();
        StartCoroutine(MakeNPC());
        StartCoroutine(MakeSpecialNPC());
    }

    private IEnumerator MakeNPC()
    {
        while (true)
        {
            if (CheckAllNPCIsSpawn())
            {
                yield return new WaitForSeconds(spawnTime);
                continue;
            }        

            int posIndex = ReturnRandPosIndex();
            int avatarIndex = ReturnRandNPCAvatarIndex();

            usingNPCIndex[posIndex] = true;

            GameObject npc = npcPool.SpawnNPC(NPCSpawnPoints[posIndex].transform.position, NPCAvatars[avatarIndex], posIndex);
            if (npc == null)
                usingNPCIndex[posIndex] = false;
           
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private IEnumerator MakeSpecialNPC()
    {
        while (true)
        {
            if (SpecialNPCISSpawn)
            {
                yield return new WaitForSeconds(specialNPCSpawnTime);
                continue;
            }


            int posIndex = Random.Range(0, SpecialNPCSpawnPoints.Length);

            ChangeSpecialNPCISSpawnState(true);
            GameObject speicalNPC = npcPool.SpawnSpecialNPC(SpecialNPCSpawnPoints[posIndex].transform.position);
            EffectManager.Instance.Play(AppearanceEffectType, SpecialNPCSpawnPoints[posIndex].transform.position + new Vector3(0, 3.5f, 0));
            if (speicalNPC == null)
                ChangeSpecialNPCISSpawnState(false);

            yield return new WaitForSeconds(specialNPCSpawnTime);
        }
    }

    private int ReturnRandNPCAvatarIndex()
    {
        int randIndex = Random.Range(0, NPCAvatars.Length); // 0 ~ 3

        return randIndex;
    }

    private int ReturnRandPosIndex()
    {
        int randIndex = Random.Range(0, NPCSpawnPoints.Length); // 0 ~ 3

        while (usingNPCIndex[randIndex])
        {
            randIndex = Random.Range(0, NPCSpawnPoints.Length);
        }
        return randIndex;
    }

    public void DeactivateNPCIndexState(int index)
    {
        usingNPCIndex[index] = false;
    }

    private bool CheckAllNPCIsSpawn()
    {
        for(int i=0; i< usingNPCIndex.Length; i++)
        {
            if (!usingNPCIndex[i])
                return false;   
        }
        //Debug.Log("All true");
        return true;
    }
    
    private void InitUsingNpcIndex()
    {
        for (int i = 0; i < usingNPCIndex.Length; i++)
        {
            usingNPCIndex[i] = false;
        }
    }

    public void ReleaseNPC(GameObject obj)
    {
        npcPool.ReleaseNPC(obj);
    }

    public void ReleaseSpecialNPC(GameObject obj)
    {
        npcPool.ReleaseSpecialNPC(obj);
    }

    public void ChangeSpecialNPCISSpawnState(bool value)
    {
        SpecialNPCISSpawn = value;
    }

    public void MakeTalkEffect(Vector3 pos, string name)
    {
        SetAudioClip(name);
        audioSource.Play();

        EffectManager.Instance.Play(TalkEffectType, pos);
    }

    private void SetAudioClip(string name)
    {
        audioSource.clip = AudioManager.Instance.ReturnAudioClip(name);
    }

    private void OnDisable()
    {
        audioSource.enabled = false;
    }
}
