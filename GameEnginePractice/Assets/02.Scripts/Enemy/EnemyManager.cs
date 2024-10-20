using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    // 프리팹
    public GameObject Zombie_Prefab;
    public GameObject Pierrot_Prefab;
    public GameObject Killer_Prefab;

    // 이펙트
    public GameObject Pierrot_AppearanceEffect;
    public GameObject Zombie_AppearanceEffect;
    public GameObject Killer_AppearanceEffect;

    public GameObject Pierrot_AreaEffect;

    // 타겟
    public GameObject Player_Obj;

    // 생성된 적
    List<GameObject> enemys = new List<GameObject> ();
    List<int> enemyToAppear =   new List<int> ();

    // 스폰 포인트
    public Transform[] EnemySpawnPoints = new Transform[3];

    float enemySpawnTime = 10f; //7

    // 적마다 빼앗은 사탕 개수
    int[] getCandyCnt = new int[3];

    PuzzleUIManager puzzleUIManager;

    private void Start()
    {
        puzzleUIManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<PuzzleUIManager>();
        ResetGetCandyCnt();
        enemys.Clear();
        enemyToAppear.Clear();
        StartCoroutine(MakeEnemys());
    }


    GameObject MakeObj(GameObject prefab, Vector3 pos)
    {
        return Instantiate(prefab, pos, Quaternion.identity, transform);
    }

    void AddList(string type, GameObject obj)
    {
        switch(type)
        {
            case "enemys":
                enemys.Add(obj);
                break;
            default:
                Debug.LogWarning(type);
                break;
        }
    }

    IEnumerator MakeEnemys()
    {
        GameObject tmp = null;
        int randEnemyIndex = 0;
        Vector3 randPos = Vector3.zero;
        while(true)
        {
            yield return new WaitForSeconds(enemySpawnTime);

            if (puzzleUIManager.CheckIfCanvasIsActivated()) // 플레이어가 퍼즐을 풀고있을 경우
                continue;

            if (enemys.Count > 3)
                continue;
            

            randEnemyIndex = ReturnRandEnemyIndex();//
            enemyToAppear.Add(randEnemyIndex);
            randPos = ReturnRandPos();
            if (randEnemyIndex == 0)
            {
                //Debug.Log("좀비 생성");
                StartCoroutine(MakeAppearanceEffect(randEnemyIndex, randPos));
                tmp = MakeObj(Zombie_Prefab, randPos);
                tmp.name = "Zombie";
                AddList("enemys", tmp);
            }
            else if (randEnemyIndex == 1)
            {
                //Debug.Log("삐에로 생성");
                StartCoroutine(ManagePierrotAppearance(Pierrot_AreaEffect, Player_Obj.transform.position));
            }
            else if (randEnemyIndex == 2)
            {
                //Debug.Log("체인쏘우 생성");
                StartCoroutine(MakeAppearanceEffect(randEnemyIndex, randPos));
                tmp = MakeObj(Killer_Prefab, randPos);
                tmp.name = "Chainsaw";
                AddList("enemys", tmp);
            }
        }
    }

    void RemoveListElement(string type, GameObject obj)
    {
        switch (type)
        {
            case "enemy":
                enemys.Remove(obj);
                break;
            default:
                Debug.LogWarning("type : " + type);
                break;
        }
    }


    IEnumerator ManagePierrotAppearance(GameObject obj, Vector3 pos)
    {
        GameObject tmpObj = null;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.4f - 0.1f * i);
            tmpObj = MakeObj(obj, pos);
            if(i==1)
                tmpObj.transform.localScale = Vector3.one * 0.3f;
            else if(i==2)
                tmpObj.transform.localScale = Vector3.one * 0.5f;;
            yield return new WaitForSeconds(0.4f - 0.1f * i);
            Destroy(tmpObj);
        }

        if (puzzleUIManager.CheckIfCanvasIsActivated())
            yield break;

        StartCoroutine(MakeAppearanceEffect(1, pos));
        tmpObj = MakeObj(Pierrot_Prefab, pos);
        tmpObj.name = "Pierrot";
        AddList("enemys", tmpObj);
    }

    public void RemoveObj(string type, GameObject obj)
    {
        Destroy(obj);
        RemoveListElement(type, obj);
    }

    Vector3 ReturnRandPos()
    {
        int randIndex = Random.Range(0, EnemySpawnPoints.Length); // 0 ~ 3
        return EnemySpawnPoints[randIndex].transform.position;
    }

    int ReturnRandEnemyIndex()
    {
        
        // 0 : 좀비
        // 1 : 삐에로
        // 2 : 식구
        int randIndex = 0; // 0 ~ 2

        // 차례대로 적이 한번씩 등장하게 하고 그 뒤로부터는 랜덤하게 나오도록 설정
        if (enemyToAppear.Count == 0)
            randIndex = 0;
        else if (enemyToAppear.Count == 1)
            randIndex = 1;
        else if (enemyToAppear.Count == 2)
            randIndex = 2;
        else
            randIndex = Random.Range(0, 3);

        return randIndex;
    }

    IEnumerator MakeAppearanceEffect(int index, Vector3 pos)
    {
        GameObject tmp = null;

        if (index == 0)
            tmp = Instantiate(Zombie_AppearanceEffect, pos, Quaternion.identity);
        else if (index == 1)
            tmp = Instantiate(Pierrot_AppearanceEffect, pos, Quaternion.identity);
        else if (index == 2)
            tmp = Instantiate(Killer_AppearanceEffect, pos, Quaternion.identity);
        else
            Debug.LogWarning(index);
        yield return new WaitForSeconds(1f);
        Destroy(tmp);
    }

    void ResetGetCandyCnt()
    {
        for (int i = 0; i < getCandyCnt.Length; i++)
            getCandyCnt[i] = 0;
    }

    public void ChangeGetCandyCnt(string EnemyName)
    {
        if(EnemyName.Contains("Zombie"))
            getCandyCnt[0]++;
        else if(EnemyName.Contains("Pierrot"))
            getCandyCnt[1]++;
        else if (EnemyName.Contains("Chainsaw"))
            getCandyCnt[2]++;
    }

    public int ReturnGetCandyCnt(int index)
    {
        return getCandyCnt[index];
    }
}
