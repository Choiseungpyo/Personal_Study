using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    public TMP_Text Level_Txt;

    /// <summary>
    /// ���� �ؽ�Ʈ�� ���� �����Ѵ�. 
    /// </summary>
    /// <param name="value">���� ����</param>
    public void SetLevel_Txt(int currentLevel)
    {
        Level_Txt.text = currentLevel.ToString();
    }
}
