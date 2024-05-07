using OpenCover.Framework.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptManager : MonoBehaviour
{

    ExpUIManager expUIManager;
    ReinforceUIManager reinforceUIManager;

    public static ScriptManager instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        expUIManager = GameObject.Find("UIManager").GetComponent<ExpUIManager>();
        reinforceUIManager = GameObject.Find("UIManager").GetComponent<ReinforceUIManager>();

        //AccessOtherScript(ExpUIManager);
    }
    
    //public U AccessOtherScript<T, U>(T value)
    //{
    //    //if (value.GetType() == typeof(ReinforceUIManager))
    //    //    return reinforceUIManager;

    //    return " ";
    //}
}
