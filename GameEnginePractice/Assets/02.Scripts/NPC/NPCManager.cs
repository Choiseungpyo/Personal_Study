using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCManager : MonoBehaviour
{
    public GameObject NPCPrefab;
    public GameObject SpecialNPCPrefab;
    public Avatar[] NPCAvatars = new Avatar[3];

    // À§Ä¡
    public Transform[] NPCSpawnPoints = new Transform[4];
    public Transform[] SpecialNPCSpawnPoints = new Transform[4];
    
    // ÀÌÆåÆ®
    public GameObject TalkEffect_Prefab;
    public GameObject AppearanceEffect_Prefab;

    GameObject TalkEffectObj = null;
    GameObject AppearanceEffect = null;

    int spawnTime = 10;
    int specialNPCSpawnTime = 30;

    bool[] usingNPCIndex = new bool[4];
    bool SpecialNPCISSpawn = false;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ChangeSpecialNPCISSpawnState(false);
        InitUsingNpcIndex();
        StartCoroutine(MakeNPC());
        StartCoroutine(MakeSpecialNPC());
    }

    IEnumerator MakeNPC()
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

            ChangeNPCAvatar(avatarIndex);
            GameObject npc = Instantiate(NPCPrefab, NPCSpawnPoints[posIndex].transform.position, Quaternion.identity, transform);
            npc.GetComponent<NPC>().ChangePosIndex(posIndex);
           
            yield return new WaitForSeconds(spawnTime);
        }
    }

    IEnumerator MakeSpecialNPC()
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
            GameObject speicalNPC = Instantiate(SpecialNPCPrefab, SpecialNPCSpawnPoints[posIndex].transform.position, Quaternion.identity, transform);
            AppearanceEffect = Instantiate(AppearanceEffect_Prefab, SpecialNPCSpawnPoints[posIndex].transform.position + new Vector3(0,3.5f,0), Quaternion.identity, transform);
            Destroy(AppearanceEffect, 1.0f);
            speicalNPC.name = "SpecialNPC";

            yield return new WaitForSeconds(specialNPCSpawnTime);
        }
    }


    int ReturnRandNPCAvatarIndex()
    {
        int randIndex = Random.Range(0, NPCAvatars.Length); // 0 ~ 3

        return randIndex;
    }

    int ReturnRandPosIndex()
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

    bool CheckAllNPCIsSpawn()
    {
        for(int i=0; i< usingNPCIndex.Length; i++)
        {
            if (!usingNPCIndex[i])
                return false;   
        }
        //Debug.Log("All true");
        return true;
    }
    
    void InitUsingNpcIndex()
    {
        for (int i = 0; i < usingNPCIndex.Length; i++)
        {
            usingNPCIndex[i] = false;
        }
    }

    void ChangeNPCAvatar(int index)
    {
        NPCPrefab.GetComponent<Animator>().avatar = NPCAvatars[index];
    }

    public void ChangeSpecialNPCISSpawnState(bool value)
    {
        SpecialNPCISSpawn = value;
    }

    public void MakeTalkEffect(Vector3 pos, string name)
    {
        SetAudioClip(name);
        audioSource.Play();

        TalkEffectObj = Instantiate(TalkEffect_Prefab, pos, Quaternion.identity);
        Destroy(TalkEffectObj, 1.0f);
    }

    void SetAudioClip(string name)
    {
        audioSource.clip = AudioManager.instance.ReturnAudioClip(name);
    }

    private void OnDisable()
    {
        audioSource.enabled = false;
    }
}
