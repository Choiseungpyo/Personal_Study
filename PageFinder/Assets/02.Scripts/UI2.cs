using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI2 : MonoBehaviour
{
    Player tmp;
    public Button ColorChangeBtn;

    private void Start()
    {
        tmp = GameObject.Find("Player").GetComponent<Player>();
    }
    public void ChangeBtnPressedColor()
    {
        ColorBlock colorBlock = ColorChangeBtn.colors;
        colorBlock.pressedColor = tmp.ReturnGroudColor();
        ColorChangeBtn.colors = colorBlock;
    }

    public void ClickChangeColorBtn()
    {
        Color useToColor = tmp.ReturnGroudColor();
        tmp.ChangeColorToUse(useToColor);
    }


}
