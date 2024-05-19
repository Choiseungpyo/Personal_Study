using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemyManager : MonoBehaviour
{
    // 프리팹
    public GameObject Zombie_Prefab;
    public GameObject Pierrot_Prefab;
    public GameObject Killer_Prefab;

    // 이펙트
    public GameObject Pierrot_AppearanceEffect;
    public GameObject Pierrot_AreaEffect;

    // 생성된 적
    List<GameObject> enemys = new List<GameObject> ();
    List<GameObject> areaEffects = new List<GameObject> ();
    List<GameObject> appearanceEffects = new List<GameObject> ();

    // 스폰 포인트
    public Transform[] EnemySpawnPoints = new Transform[4];


    private void Start()
    {
        Vector3 pos = new Vector3(-15, 0, 5);
        //StartCoroutine(ManagePierrotAppearance(Pierrot_AreaEffect, pos));
        
    }

    private void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //    AddList("enemy", MakeObj(Zombie_Prefab, ReturnRandPos()));
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
        return EnemySpawnPoints[randIndex].transform.position;
    }
}
