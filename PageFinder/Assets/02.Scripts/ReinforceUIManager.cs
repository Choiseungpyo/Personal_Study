using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.WSA;

public class ReinforceUIManager : MonoBehaviour
{
    public Canvas Reinforce_Canvas;
    public Image[] Content_Img = new Image[3];  // ���� ���� �̹���
    public TMP_Text[] Title_Txt = new TMP_Text[3];      // �̹����� ���� ���� ���� 
    public TMP_Text[] Content_Txt = new TMP_Text[3];    // ���� ���� ���� ���� 
    public Sprite[] content_Spr = new Sprite[6];
    // ���� ����� ����ü�� � ������ ���ִ����� ǥ���ؾ��� 
    List<int> icurrentReinforceBodys = new List<int>() { 4, 1, 5 };

    bool didSelectReinforceBody = false;


    ExpUIManager expUIManager;

    private void Start()
    {
        expUIManager = GameObject.Find("UIManager").GetComponent<ExpUIManager>();
        SetUI();
        ChangeReinforceCanvasState(false);
    }

    

    /// <summary>
    /// ���� ���� �̹����� �����ϴ� �Լ�
    /// </summary>
    public void ChangeImgsContent()
    {
        for (int i = 0; i < Content_Img.Length; i++)
        {
            Content_Img[i].sprite = content_Spr[icurrentReinforceBodys[i]]; 
        }
            
    }

    void ChangeTitleTxt()
    {
        for (int i = 0; i < Title_Txt.Length; i++)
            Title_Txt[i].text = ReturnTitleTxt(icurrentReinforceBodys[i]);
    }

    string ReturnTitleTxt(int n)
    {
        /*
       *  0 : �ִ� ü��
       *  1 : ���ݷ�
       *  2 : �ֹ���
       *  3 : �ִ� ����
       *  4 : �ȷ�Ʈ
       *  5 : ��ų
       */
        switch (n)
        {
            case 0:
                return "MaxHp";
            case 1:
                return "AttackPower";
            case 2:
                return "MagicalPower";
            case 3:
                return "MaxMana";
            case 4:
                return "Palette";
            case 5:
                return "Skill";
            default:
                Debug.LogWarning(n  + " �ε��� �� ���� �߸��� �Է�");
                return "Error";
        }
    }

    void ChangeContentTxt()
    {
        for (int i = 0; i < Content_Txt.Length; i++)
            Content_Txt[i].text = ReturnContentTxt(icurrentReinforceBodys[i]);
    }

    string ReturnContentTxt(int n)
    {
        /*
       *  0 : �ִ� ü��
       *  1 : ���ݷ�
       *  2 : �ֹ���
       *  3 : �ִ� ����
       *  4 : �ȷ�Ʈ
       *  5 : ��ų
       */
        switch (n)
        {
            case 0:
                return "Max Hp ++";
            case 1:
                return "AttackPower ++";
            case 2:
                return "MagicalPower ++";
            case 3:
                return "MaxMana ++";
            case 4:
                return "Color A ++";
            case 5:
                return "Skill A ++";
            default:
                Debug.LogWarning(n + " �ε��� �� ���� �߸��� �Է�");
                return "Error";
        }
    }

    /// <summary>
    /// ����ü�� �������� ��� �����ϴ� �Լ�
    /// </summary>
    public void SelectReinforcedBody()
    {
        GameObject clickBtn = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < Content_Img.Length; i++)
        {
            if (clickBtn.name.Contains(i.ToString()))
            {
                ChangeDidSelectReinforceBody(true);
                ReinforceSelectedBody(i);
                ChangeReinforceCanvasState(false);
                expUIManager.ResetExpBar();
                break;
            }
        }
    }

    /// <summary>
    /// ������ ����ü�� ��ȭ�Ѵ�. 
    /// </summary>
    /// <param name="n">��ȭ�� ����ü ��ȣ</param>
    void ReinforceSelectedBody(int n)
    {
        /*
         *  0 : �ִ� ü��
         *  1 : ���ݷ�
         *  2 : �ֹ���
         *  3 : �ִ� ����
         *  4 : �ȷ�Ʈ
         *  5 : ��ų
         */
        switch (n)
        {
            case 0:
                // playerScripts.MaxHp �� ���� 
                break;
            case 1:
                // playerScripts.attackPower �� ���� 
                break;
            case 2:
                // playerScripts.magicalPower �� ���� 
                break;
            case 3:
                // playerScripts. �� ���� 
                break;
            case 4:
                // paletteScripts.totalColor �� �߰�
                break;
            case 5:
                // playerScripts.skill �߰� 
                break;

        }
    }

    /// <summary>
    /// icurrentReinforceBodys ����Ʈ�� ���� �߰��Ѵ�. 
    /// </summary>
    /// <param name="reinforcedBodyNum">�߰��� ����ü�� ��ȣ</param>
    void AddReinforceBody(int reinforcedBodyNum)
    {
        icurrentReinforceBodys.Add(reinforcedBodyNum);
    }

    /// <summary>
    /// icurrentReinforceBodys ����Ʈ ���� ���� ���� �����. 
    /// </summary>
    void ResetICurrentReinforceBodys()
    {
        icurrentReinforceBodys.Clear();
    }

    /// <summary>
    /// icurrentReinforceBodys�� ���� �����Ѵ�. 
    /// </summary>
    void SetICurrentReinforceBodys()
    {
        int randomNum = 0;
        for (int i = 0; i < 3; i++)
        {
            randomNum = ReturnReinforcedBodyRandNum();
            AddReinforceBody(randomNum);
        }     
    }

    /// <summary>
    /// ��ȭ�� ����ü�� ��ȣ�� �������� �����Ѵ�. 
    /// </summary>
    /// <returns>��ȭ�� ����ü�� ��ȣ</returns>
    int ReturnReinforcedBodyRandNum()
    {
        int randomNum = Random.Range(0, 6); // 0 ~ 6
        while (icurrentReinforceBodys.IndexOf(randomNum) != -1) // icurrentReinforceBodys ����Ʈ�� �̹� ����ü ��ȣ�� �ִ� ���
            randomNum = Random.Range(0, 6); // �ٽ� �������� ���� ����
        return randomNum;
    }


    void SetUI()
    {
        ResetICurrentReinforceBodys();  // icurrentReinforceBodys ����
        SetICurrentReinforceBodys();    // icurrentReinforceBodys �� ����
        //Debug.Log(icurrentReinforceBodys.Count);
        ChangeImgsContent(); // �̹��� ����
        ChangeTitleTxt();    // ���� �ؽ�Ʈ ����
        ChangeContentTxt();  // ���� �ؽ�Ʈ ����
    }


    public void ChangeReinforceCanvasState(bool value)
    {
        Reinforce_Canvas.gameObject.SetActive(value);
    }

    public void ActivateReinforceUI()
    {
        ChangeReinforceCanvasState(true);
        SetUI();
    }

    public void ChangeDidSelectReinforceBody(bool value)
    {
        didSelectReinforceBody = value;
    }

    public bool ReturnDidSelectReinforceBody()
    {
        return didSelectReinforceBody;
    }
}
