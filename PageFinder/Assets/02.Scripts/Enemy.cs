using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private void OnTriggerStay(Collider coll)
    {
        if (!coll.CompareTag("Weapon"))
            return;
        //Debug.Log(GameObject.Find("Player").GetComponent<Player>().ReturnState());
        if (!GameObject.Find("Player").GetComponent<Player>().CheckAttackAniIsPlaying())
            return;
        // �÷��̾ ���� ���� + ����� �ε����� ��
        //gameObject.GetComponent<MeshRenderer>().material.color = Palette.instance.ReturnCurrentColor();
        gameObject.GetComponent<MeshRenderer>().material.color = GameObject.Find("Player").GetComponent<Player>().ReturnColorToUse();
    }
}
