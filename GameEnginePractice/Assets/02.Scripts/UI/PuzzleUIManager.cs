using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleUIManager : MonoBehaviour
{
    /* [0] : -160, 160      [1] : 0, 160        [2] : 160, 160
     * [3] : -160, 0        [x] : 0, 0          [4] : 160, 0
     * [5] : -160, -160     [6] : 0, -160       [7] : 160, -160
     */
    public Canvas PuzzleUICanvas;
    public GameObject FinalPuzzlePiece;
    public GameObject PuzzlePiece;
    Transform EmptyPiece;
    Transform clickedPuzzlePiece;

    private void Start()
    {
        // ���߿� �����ϰ� �ٲٱ�
        // �� �߾� 
        SetRandomEmptyPiece();
    }

    // x���� 160 ���̳��ų� y���� 160 ���� ���� ��� 
    public void ClickPuzzlePiece()
    {
        if (clickedPuzzlePiece != null)
            return;
        //Debug.Log("Ŭ��");
        clickedPuzzlePiece = EventSystem.current.currentSelectedGameObject.transform;
        //Debug.Log("Ŭ���� ���� : " + clickedPuzzlePiece);
        //Debug.Log("����ִ� ���� : " + EmptyPiece.localPosition);

        if(CheckPuzzlePiece())
            StartCoroutine(MovePuzzlePiece());

    }

    bool CheckPuzzlePiece()
    {
        // ����ִ� ���� ������ ������ ���� ������  �̿��� ���� ��� 
        if (clickedPuzzlePiece.localPosition.x == EmptyPiece.localPosition.x)
        {
            if (Mathf.Abs(clickedPuzzlePiece.localPosition.y - EmptyPiece.localPosition.y) == 160)
                return true;
            return false;
        }
        if(clickedPuzzlePiece.localPosition.y == EmptyPiece.localPosition.y)
        {
            if (Mathf.Abs(clickedPuzzlePiece.localPosition.x - EmptyPiece.localPosition.x) == 160)
                return true;
            return false;
        }
 
        return false;
    }

    IEnumerator MovePuzzlePiece()
    {
        Vector3 orinalClickedPuzzlePiecePos = clickedPuzzlePiece.localPosition;
        while (Vector3.Distance(clickedPuzzlePiece.localPosition, EmptyPiece.localPosition) > 0)
        {
            clickedPuzzlePiece.localPosition = Vector3.MoveTowards(clickedPuzzlePiece.localPosition, EmptyPiece.localPosition, 1.5f);
            yield return null;
        }
        ChangeEmptyPiecePos(orinalClickedPuzzlePiecePos);
    }

    void ChangeEmptyPiecePos(Vector3 pos)
    {
        EmptyPiece.localPosition = pos;
        clickedPuzzlePiece = null;
    }

    void SetRandomEmptyPiece()
    {
        int randNum = Random.Range(0, 9); // 0 ~ 8

        EmptyPiece = PuzzlePiece.transform.GetChild(randNum).gameObject.transform;
        EmptyPiece.name = "EmptyPiece";
        EmptyPiece.GetComponent<Image>().raycastTarget = false;
        EmptyPiece.GetComponent<Button>().interactable = false;
        EmptyPiece.gameObject.SetActive(false);

        FinalPuzzlePiece.GetComponent<Image>().sprite = EmptyPiece.GetComponent<Image>().sprite;
    }

    void ShufflePuzzlePiece()
    {

    }
}