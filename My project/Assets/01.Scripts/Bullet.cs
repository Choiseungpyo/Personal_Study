using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Sprite[] BulletSprites = new Sprite[2];

    int speed = 5;
    Vector3 dir = Vector3.zero;
    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += dir * Time.deltaTime * speed;
    }

    public void SetDir(char value)
    {
        if(value == 'L')
        {
            dir = Vector3.left;
            gameObject.GetComponent<SpriteRenderer>().sprite = BulletSprites[0];
        }
        else if (value == 'R')
        {
            dir = Vector3.right;
            gameObject.GetComponent<SpriteRenderer>().sprite = BulletSprites[1];
        }        
    }
}
