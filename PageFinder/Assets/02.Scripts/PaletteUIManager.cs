using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PaletteUIManager : MonoBehaviour
{
    public Canvas PaletteCanvas;
    public GameObject[] Obj_ColorSet = new GameObject[4]; // 사용할 색깔들의 부모 객체
    List<Image> Img_ColorIcon = new List<Image>(); // 사용할 색깔들 
    public Image Img_CurrentColorIcon;

    // 총 사용하는 색깔 3 -> Obj_ColorSet[0]
    // 총 사용하는 색깔 4 -> Obj_ColorSet[1]
    // 총 사용하는 색깔 5 -> Obj_ColorSet[2]
    // 총 사용하는 색깔 6 -> Obj_ColorSet[3]

    float clickTimeAboutColorIconBtn = 0;
    bool isClickColorIconBtn = false;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        SetColorIcon(false);
    }


    private void Update()
    {
        //Debug.Log(Input.mousePosition);
        CheckColorIconButtonClickTime();
    }


    // 맨 처음에는 현재 색깔 아이콘만 뜨게함
    // 해당 아이콘 클릭시 변경할 수 있는 색깔이 위 아래로 뜸
    

    // 만약 드래그 후 해당 색깔 아이콘 위치까지 갔을 경우 
    // 해당 색깔 아이콘의 투명도를 1로 변경하여 해당 위치까지 갔다는 것을 알린다. 
    
   public void ColorIconButtonDown()
    {
        isClickColorIconBtn = true;
        //Debug.Log("버튼 누름");
        SetColorIcon(true);
    }

    public void ColorIconButtonUp()
    {
        if (clickTimeAboutColorIconBtn > 0.5f)
        {
            for (int i = 0; i < Img_ColorIcon.Count; i++)
            {
                if (CheckMousePos(Input.mousePosition, i))
                {
                    //Debug.Log("아이콘 선택");
                    //Debug.Log("변경할 색깔 : " + Palette.instance.ReturnIconColorToUse(i));
                    //Debug.Log("Button Up");
                    Img_CurrentColorIcon.color = Palette.instance.ReturnIconColorToUse(i);
                    Palette.instance.ChangeCurrentColor(Img_CurrentColorIcon.color);
                    Palette.instance.ChangeColorOfObj();
                    break;
                }
            }       
        }
        isClickColorIconBtn = false;
        clickTimeAboutColorIconBtn = 0;

        ChangeObj_ColorSet_State(false); // 색깔 집합 비활성화
    }

    public void CheckColorIconButtonClickTime()
    {
        if (!isClickColorIconBtn)
            return;

        clickTimeAboutColorIconBtn += Time.deltaTime;  
    }
    
    bool CheckMousePos(Vector3 mousePos, int colorIconIndexToWant)
    {
        int totalColorCount = Palette.instance.ReturnTotalColorCount() - 3;
        float width = Obj_ColorSet[totalColorCount].GetComponentInChildren<Image>().rectTransform.rect.width;
        float height = Obj_ColorSet[totalColorCount].GetComponentInChildren<Image>().rectTransform.rect.height;

        if (mousePos.x < Img_ColorIcon[colorIconIndexToWant].transform.position.x - width / 2 
            || mousePos.x > Img_ColorIcon[colorIconIndexToWant].transform.position.x + width / 2)
            return false;
        if (mousePos.y < Img_ColorIcon[colorIconIndexToWant].transform.position.y - height / 2
            || mousePos.y > Img_ColorIcon[colorIconIndexToWant].transform.position.y + height / 2)
                return false;

        return true;
    }


    void ChangeObj_ColorSet_State(bool value)
    {
        int objToSelet = Palette.instance.ReturnTotalColorCount() -3;

        for (int i = 0; i < Obj_ColorSet.Length; i++)
        {
            if(objToSelet == i)
            {
                Obj_ColorSet[i].SetActive(value);
                //Debug.Log(i + " : true");
            }
            else
            {
                Obj_ColorSet[i].SetActive(false);
                //Debug.Log(i + " : false");
            }     
        }
    }

    void SetColorToChange_Obj_Color(int colorIndex)
    {
        Img_ColorIcon[colorIndex].color = Palette.instance.ReturnIconColorToUse(colorIndex);            
    }

    void Add_ListImg_ColorIcon(int colorSetIndex, int colorIconIndex)
    {
        Img_ColorIcon.Add(Obj_ColorSet[colorSetIndex].transform.GetChild(colorIconIndex).GetComponent<Image>());
    }

    void SetImg_ColorIcon()
    {
        int totalColorCount = Palette.instance.ReturnTotalColorCount() -1;
        int colorSetIndex = Palette.instance.ReturnTotalColorCount() - 3;
        int colorIconIndex = 0;
        Img_ColorIcon.Clear(); // 한번 리스트 비우기

        // Img_ColorIcon 리스트에 사용하는 색깔 객체들 저장
        for (; colorIconIndex < totalColorCount; colorIconIndex++)
        {
            //Debug.Log("추가할 자식객체 번호 : " + colorIconIndex);
            Add_ListImg_ColorIcon(colorSetIndex, colorIconIndex); // 사용하는 색깔 아이콘 리스트에 저장
            SetColorToChange_Obj_Color(colorIconIndex); // 아이콘 색깔 배정
        }
        Img_ColorIcon.Add(Img_CurrentColorIcon); // 사용하는 색깔 아이콘 리스트에 저장
        SetColorToChange_Obj_Color(colorIconIndex); // 아이콘 색깔 배정
    }

    void SetColorIcon(bool valueToActivate)
    {
        ChangeObj_ColorSet_State(valueToActivate); // 현재 해당하는 색깔 집합만 활성화
        SetImg_ColorIcon(); // 사용하는 색깔들을 리스트에 저장
    }
}
