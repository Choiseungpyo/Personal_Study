using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;

public class NPCManager : MonoBehaviour
{
    public GameObject NPCPrefab;
    public Avatar[] NPCAvatars = new Avatar[3];
    public Transform[] NPCSpawnPoints = new Transform[4];

    int spawnTime = 10;
    Vector3[] NPCSpawnDir = new Vector3[4];

    bool[] usingNPCIndex = new bool[4];

    private void Start()
    {
        //Vector3[0] = 

        InitUsingNpcIndex();
        StartCoroutine(MakeNPC());
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
}
