using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    Animator myAnimator;
    float counter;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myAnimator.SetBool("bSpace", false);
        myAnimator.SetFloat("fHP", 0.0f);
        counter = 70.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetBool("bSpace", true);
            Debug.Log("space pressed");
        }else if (Input.GetKeyDown(KeyCode.A))
        {
            counter += 10;
            myAnimator.SetFloat("fHP", counter);
            Debug.Log("A pressed");
        }
    }
}
