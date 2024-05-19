using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject BulletPrefab;

    public int Speed = 3;
    bool hasGun = false;



    Animator ani;
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * Time.deltaTime * Speed;

            ani.SetTrigger("move_up");
            ani.SetBool("idle", false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * Time.deltaTime * Speed;

            ani.SetTrigger("move_down");
            ani.SetBool("idle", false);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * Speed;

            if (hasGun)
                ani.SetTrigger("gun_move_left");
            else
                ani.SetTrigger("move_left");
            ani.SetBool("idle", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * Speed;

            if (hasGun)
                ani.SetTrigger("gun_move_right");
            else
                ani.SetTrigger("move_right");
            ani.SetBool("idle", false);
        }

        if(!Input.anyKey)
        {
            ani.SetBool("idle", true);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (!hasGun)
                return;

            if(ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Left") || ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Left")
                || ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Bullet_Move_Left") || ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Bullet_Idle_Left"))
            {
                GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().SetDir('L');
            }
            else if (ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Right") || ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Move_Right")
                || ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Bullet_Move_Right") || ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Bullet_Idle_Right"))
            {
                GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().SetDir('R');
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "Gun")
        {
            Debug.Log("√— ∏‘¿Ω");
            hasGun = true;
            coll.gameObject.SetActive(false);
        }
    }
}
