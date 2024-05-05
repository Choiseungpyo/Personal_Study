using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
    Color currentColor = Color.green; //    0:��     1:��     2:��

    List<Color> totalColors = new List<Color>() { Color.red, Color.blue, Color.green }; // ����Ʈ ��� ���� : ���� �� ��� �߰��ϰų� ������ �� �ֱ⿡ 

    bool test = true;

    public static Palette instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ChangeColorOfObj();
    }

    private void Update()
    {
        // �׽�Ʈ�� input
        if (!test)
        {
            if (Input.GetKey(KeyCode.Alpha0))
                test = true;
            return;
        }
            

        if (Input.GetKey(KeyCode.Alpha1))
        {
            totalColors.Add(Color.yellow);
            Debug.Log(totalColors.Count);
            test = false;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            totalColors.Add(Color.magenta);
            Debug.Log(totalColors.Count);
            test = false;
        }      
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            totalColors.Add(Color.cyan);
            Debug.Log(totalColors.Count);
            test = false;
        }
            
        
    }

    public void ChangeCurrentColor(Color color)
    {
        if (color.Equals(Color.red))
            currentColor = Color.red;
        else if (color.Equals(Color.green))
            currentColor = Color.green;
        else if (color.Equals(Color.blue))
            currentColor = Color.blue;
        else if (color.Equals(Color.magenta))
            currentColor = Color.magenta;
        else if (color.Equals(Color.yellow))
            currentColor = Color.yellow;
        else if (color.Equals(Color.cyan))
            currentColor = Color.yellow;
        else
        {
            Debug.LogWarning("���� ���� �ѱ�");
            currentColor = Color.clear;
        }
            

        Debug.Log("�ٲ� ���� : " + currentColor);
    }

    public void ChangeColorOfObj()
    {
        Weapon.instance.ChangeColor(GameObject.Find("Player").GetComponent<Player>().ReturnColorToUse());
    }

    public Color ReturnIconColorToUse(int colorIndex) // ���� ������ ����, ���� ������ ����, �Ʒ� ������ ����
    {
        if (colorIndex >= totalColors.Count) // totalColors�� �ִ� �ε��� ���� �Ѿ�� ���
        {
            Debug.LogWarning("�ε��� �ʰ�");
            return Color.clear;
        }
        else if (colorIndex == totalColors.Count - 1) // ���� ������ �ε����� ���
        {
            return currentColor;
        }

        int tmp = ReturnColorIndex(colorIndex);
        //Debug.Log("������ �ε��� : " + colorIndex + " ->" +" �ٲ� �ε��� : " + tmp);
        return totalColors[ReturnColorIndex(colorIndex)];
    }

    int ReturnColorIndex(int index)
    {
        // ��, �� ��
        // ������� ��
        int currentColorIndex = totalColors.IndexOf(currentColor);

        if (currentColorIndex == -1)
        {
            Debug.LogWarning("���� ������ ��ü �����߿� ����");
            return 0;
        }
        else if (currentColorIndex == 0) // ���� ������ ��ü ���� �� ���� ù��° �ε��� �� ���
        {
            return index + 1;
        }
        else if (currentColorIndex == totalColors.Count - 1) // ���� ������ ��ü ���� �� ���� ������ �ε��� �� ���
        {
            return index;
        }
        else
        {
            if (index >= currentColorIndex)
                return currentColorIndex + (index - currentColorIndex) + 1;
            else
                return index;
        }
    }

    public int ReturnTotalColorCount()
    {
        return totalColors.Count;
    }

    public Color ReturnCurrentColor()
    {
        return currentColor;
    }
}
