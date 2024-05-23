using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    // ������
    public GameObject Zombie_Prefab;
    public GameObject Pierrot_Prefab;
    public GameObject Killer_Prefab;

    // ����Ʈ
    public GameObject Pierrot_AppearanceEffect;
    public GameObject Zombie_AppearanceEffect;
    public GameObject Killer_AppearanceEffect;

    public GameObject Pierrot_AreaEffect;

    // Ÿ��
    public GameObject Player_Obj;

    // ������ ��
    List<GameObject> enemys = new List<GameObject> ();

    // ���� ����Ʈ
    public Transform[] EnemySpawnPoints = new Transform[10];

    float enemySpawnTime = 5f;

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{

        //    //int randEnemyIndex = 0;
        //    //Vector3 randPos = Vector3.zero;
        //    //randEnemyIndex = ReturnRandEnemyIndex();
        //    //randPos = EnemySpawnPoints[0].transform.position; // ReturnRandPos();
        //    //GameObject tmp = MakeObj(Killer_Prefab, randPos);
        //    //AddList("enemys", tmp);
        //    //StartCoroutine( MakeAppearanceEffect(2, randPos));
        //    StartCoroutine(ManagePierrotAppearance(Pierrot_AreaEffect, Player_Obj.transform.position));
        //}
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
            randEnemyIndex = ReturnRandEnemyIndex();
            randPos = ReturnRandPos();
            if (randEnemyIndex == 0)
            {
                StartCoroutine(MakeAppearanceEffect(randEnemyIndex, randPos));
                tmp = MakeObj(Zombie_Prefab, randPos);
                tmp.name = "Zombie";
                AddList("enemys", tmp);
            }
            else if (randEnemyIndex == 1)
                StartCoroutine(ManagePierrotAppearance(Pierrot_AreaEffect, Player_Obj.transform.position));
            else if (randEnemyIndex == 2)
            {
                StartCoroutine(MakeAppearanceEffect(randEnemyIndex, randPos));
                tmp = MakeObj(Zombie_Prefab, randPos);
                tmp.name = "Chainsaw";
                AddList("enemys", MakeObj(Killer_Prefab, randPos));
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
        return EnemySpawnPoints[0].transform.position;
    }

    int ReturnRandEnemyIndex()
    {
        // 0 : ����
        // 1 : �߿���
        // 2 : �ı�

        int randIndex = Random.Range(0, 3); // 0 ~ 2
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
}
