using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpUIManager : MonoBehaviour
{
    public Canvas Exp_Canvas;
    public Slider Exp_Slid;

    bool isExpFull = false;

    ReinforceUIManager reinfoceUIManager;
    private void Start()
    {
        reinfoceUIManager = GameObject.Find("UIManager").GetComponent<ReinforceUIManager>();
        ResetExpBar();
    }

    private void Update()
    {
        CheckIfExpIsFull();
        CheckIfReinforceBodyIsSelected();
    }

    void CheckIfExpIsFull()
    {
        if (Exp_Slid.value == 1 && !isExpFull)
        {
            ChangeIsExpFull(true);
            reinfoceUIManager.ActivateReinforceUI();
            ResetExpBar();
        }
    }

    public void CheckIfReinforceBodyIsSelected()
    {
        if(reinfoceUIManager.ReturnDidSelectReinforceBody())
        {
            ChangeIsExpFull(false);
            reinfoceUIManager.ChangeDidSelectReinforceBody(false);
        }
    }

    public void ResetExpBar()
    {
        Exp_Slid.value = 0;
    }

    void ChangeIsExpFull(bool value)
    {
        isExpFull = value;
    }


}
