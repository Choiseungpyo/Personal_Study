using UnityEngine;
using UnityEngine.EventSystems; // Ű����, ���콺, ��ġ�� �̺�Ʈ�� ������Ʈ�� ���� �� �ִ� ����� ����

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;    // �߰�
    private RectTransform rectTransform;    // �߰�

    private void Awake()    // �߰�
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("Begin");

        // �߰�
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        lever.anchoredPosition = inputDir;
    }

    // ������Ʈ�� Ŭ���ؼ� �巡�� �ϴ� ���߿� ������ �̺�Ʈ    // ������ Ŭ���� ������ ���·� ���콺�� ���߸� �̺�Ʈ�� ������ ����    
    public void OnDrag(PointerEventData eventData)
    {
         Debug.Log("Drag");

        // �߰�
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        lever.anchoredPosition = inputDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         Debug.Log("End");

        // �߰�
        lever.anchoredPosition = Vector2.zero;
    }
}