using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator ani;
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Die") && ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name.Contains("Bullet"))
        {
            ani.SetTrigger("die");
        }
    }
}
