using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class Palette : MonoBehaviour
{
    Color currentColor = Color.green; //    0:빨     1:초     2:파

    List<Color> totalColors = new List<Color>() { Color.red, Color.blue, Color.green }; // 리스트 사용 이유 : 게임 시 계속 추가하거나 삭제될 수 있기에 

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
        // 테스트용 input
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
            Debug.LogWarning("없는 색깔 넘김");
            currentColor = Color.clear;
        }
            

        Debug.Log("바뀐 색깔 : " + currentColor);
    }

    public void ChangeColorOfObj()
    {
        Weapon.instance.ChangeColor(GameObject.Find("Player").GetComponent<Player>().ReturnColorToUse());
    }

    public Color ReturnIconColorToUse(int colorIndex) // 위의 아이콘 색깔, 현재 아이콘 색깔, 아래 아이콘 색깔
    {
        if (colorIndex >= totalColors.Count) // totalColors의 최대 인덱스 값을 넘어갔을 경우
        {
            Debug.LogWarning("인덱스 초과");
            return Color.clear;
        }
        else if (colorIndex == totalColors.Count - 1) // 현재 색깔의 인덱스일 경우
        {
            return currentColor;
        }

        int tmp = ReturnColorIndex(colorIndex);
        //Debug.Log("변경할 인덱스 : " + colorIndex + " ->" +" 바뀔 인덱스 : " + tmp);
        return totalColors[ReturnColorIndex(colorIndex)];
    }

    int ReturnColorIndex(int index)
    {
        // 빨, 파 초
        // 현재색깔 빨
        int currentColorIndex = totalColors.IndexOf(currentColor);

        if (currentColorIndex == -1)
        {
            Debug.LogWarning("현재 색깔이 전체 색깔중에 없음");
            return 0;
        }
        else if (currentColorIndex == 0) // 현재 색깔이 전체 색깔 중 가장 첫번째 인덱스 일 경우
        {
            return index + 1;
        }
        else if (currentColorIndex == totalColors.Count - 1) // 현재 색깔이 전체 색깔 중 가장 마지막 인덱스 일 경우
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
