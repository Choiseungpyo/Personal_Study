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
    public GameObject Pierrot_AreaEffect;
    public GameObject Zombie_AppearanceEffect;
    public GameObject Killer_AppearanceEffect;

    // 타겟
    public GameObject Player_Obj;

    // 생성된 적
    List<GameObject> enemys = new List<GameObject> ();
    List<GameObject> areaEffects = new List<GameObject> ();
    List<GameObject> appearanceEffects = new List<GameObject> ();

    // 스폰 포인트
    public Transform[] EnemySpawnPoints = new Transform[10];

    float enemySpawnTime = 5f;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int randEnemyIndex = 0;
            Vector3 randPos = Vector3.zero;
            randEnemyIndex = ReturnRandEnemyIndex();
            randPos = ReturnRandPos();
            GameObject tmp = MakeObj(Zombie_Prefab, randPos);
            tmp.name = "Chainsaw";
            AddList("enemys", tmp);
            MakeAppearanceEffect(randEnemyIndex, randPos);
        }
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
            case "areaEffects":
                areaEffects.Add(obj);
                break;
            case "appearanceEffects":
                appearanceEffects.Add(obj);
                break;
        }
    }

    IEnumerator MakeEnemys()
    {
        int randEnemyIndex = 0;
        Vector3 randPos = Vector3.zero;
        while(true)
        {
            randEnemyIndex = ReturnRandEnemyIndex();
            randPos = ReturnRandPos();
            if (randEnemyIndex == 0)
            {
                AddList("enemys", MakeObj(Zombie_Prefab, randPos));
                MakeAppearanceEffect(randEnemyIndex, randPos);
            } 
            else if (randEnemyIndex == 1)
            {
                StartCoroutine(ManagePierrotAppearance(Pierrot_AreaEffect, Player_Obj.transform.position));
                AddList("enemys", MakeObj(Zombie_Prefab, Player_Obj.transform.position));
            }
            else if (randEnemyIndex == 2)
            {
                AddList("enemys", MakeObj(Killer_Prefab, randPos));
                MakeAppearanceEffect(randEnemyIndex, randPos);
            } 
            yield return new WaitForSeconds(enemySpawnTime);
        }
    }

    void RemoveListElement(string type, GameObject obj)
    {
        switch (type)
        {
            case "enemy":
                enemys.Remove(obj);
                break;
            case "areaEffect":
                areaEffects.Remove(obj);
                break;
            case "appearanceEffect":
                appearanceEffects.Remove(obj);
                break;
            default:
                Debug.LogWarning("type : " + type);
                break;
        }
    }


    IEnumerator ManagePierrotAppearance(GameObject obj, Vector3 pos)
    {
        GameObject tmp = null;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.4f - 0.1f * i);
            tmp = MakeObj(obj, pos);
            if(i==1)
                tmp.transform.localScale = Vector3.one * 0.3f;
            else if(i==2)
                tmp.transform.localScale = Vector3.one * 0.5f;

            AddList("areaEffect", tmp);
            yield return new WaitForSeconds(0.4f - 0.1f * i);
            RemoveObj("areaEffect", tmp);
        }
        AddList("appearanceEffect", MakeObj(Pierrot_AppearanceEffect, pos));
        AddList("enemy", MakeObj(Pierrot_Prefab, pos));
    }

    public void RemoveObj(string type, GameObject obj)
    {
        Destroy(obj);
        RemoveListElement(type, obj);
    }

    Vector3 ReturnRandPos()
    {
        int randIndex = Random.Range(0, EnemySpawnPoints.Length); // 0 ~ 3
        return EnemySpawnPoints[0].transform.position;
    }

    int ReturnRandEnemyIndex()
    {
        // 0 : 좀비
        // 1 : 삐에로
        // 2 : 식구

        int randIndex = Random.Range(0, 3); // 0 ~ 2
        return randIndex;
    }

    void MakeAppearanceEffect(int index, Vector3 pos)
    {
        if(index ==0)
            Instantiate(Zombie_AppearanceEffect, pos, Quaternion.identity);
        else if(index==2)
            Instantiate(Killer_AppearanceEffect, pos, Quaternion.identity);
    }
}
