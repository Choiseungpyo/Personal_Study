using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PaletteUIManager : MonoBehaviour
{
    public Canvas PaletteCanvas;
    public GameObject[] Obj_ColorSet = new GameObject[4]; // ����� ������� �θ� ��ü
    List<Image> Img_ColorIcon = new List<Image>(); // ����� ����� 
    public Image Img_CurrentColorIcon;

    // �� ����ϴ� ���� 3 -> Obj_ColorSet[0]
    // �� ����ϴ� ���� 4 -> Obj_ColorSet[1]
    // �� ����ϴ� ���� 5 -> Obj_ColorSet[2]
    // �� ����ϴ� ���� 6 -> Obj_ColorSet[3]

    float clickTimeAboutColorIconBtn = 0;
    bool isClickColorIconBtn = false;

    // ��ũ��Ʈ ����
    Palette palette;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        palette = GameObject.FindWithTag("Player").GetComponent<Palette>();
    }
    private void Start()
    {
        SetColorIcon(false);
    }


    private void Update()
    {
        CheckColorIconButtonClickTime();
    }

   public void ColorIconButtonDown()
    {
        isClickColorIconBtn = true;
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
                    //Debug.Log("������ ����");
                    //Debug.Log("������ ���� : " + Palette.instance.ReturnIconColorToUse(i));
                    //Debug.Log("Button Up");
                    Img_CurrentColorIcon.color = palette.ReturnIconColorToUse(i);
                    palette.ChangeCurrentColor(Img_CurrentColorIcon.color);
                    palette.ChangeColorOfObj();
                    break;
                }
            }       
        }
        isClickColorIconBtn = false;
        clickTimeAboutColorIconBtn = 0;

        ChangeObj_ColorSet_State(false); // ���� ���� ��Ȱ��ȭ
    }

    public void CheckColorIconButtonClickTime()
    {
        if (!isClickColorIconBtn)
            return;

        clickTimeAboutColorIconBtn += Time.deltaTime;  
    }
    
    bool CheckMousePos(Vector3 mousePos, int colorIconIndexToWant)
    {
        int totalColorCount = palette.ReturnTotalColorCount() - 3;
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
        int objToSelet = palette.ReturnTotalColorCount() -3;

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
        Img_ColorIcon[colorIndex].color = palette.ReturnIconColorToUse(colorIndex);            
    }

    void Add_ListImg_ColorIcon(int colorSetIndex, int colorIconIndex)
    {
        Img_ColorIcon.Add(Obj_ColorSet[colorSetIndex].transform.GetChild(colorIconIndex).GetComponent<Image>());
    }

    void SetImg_ColorIcon()
    {
        int totalColorCount = palette.ReturnTotalColorCount() -1;
        int colorSetIndex = palette.ReturnTotalColorCount() - 3;
        int colorIconIndex = 0;
        Img_ColorIcon.Clear(); // �ѹ� ����Ʈ ����

        // Img_ColorIcon ����Ʈ�� ����ϴ� ���� ��ü�� ����
        for (; colorIconIndex < totalColorCount; colorIconIndex++)
        {
            //Debug.Log("�߰��� �ڽİ�ü ��ȣ : " + colorIconIndex);
            Add_ListImg_ColorIcon(colorSetIndex, colorIconIndex); // ����ϴ� ���� ������ ����Ʈ�� ����
            SetColorToChange_Obj_Color(colorIconIndex); // ������ ���� ����
        }
        Img_ColorIcon.Add(Img_CurrentColorIcon); // ����ϴ� ���� ������ ����Ʈ�� ����
        SetColorToChange_Obj_Color(colorIconIndex); // ������ ���� ����
    }

    void SetColorIcon(bool valueToActivate)
    {
        ChangeObj_ColorSet_State(valueToActivate); // ���� �ش��ϴ� ���� ���ո� Ȱ��ȭ
        SetImg_ColorIcon(); // ����ϴ� ������� ����Ʈ�� ����
    }
}
