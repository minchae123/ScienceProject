using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rect;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();

        image.color = Color.gray;
    }

    public void OnPointerEnter(PointerEventData eventData) // ���η� ���� ��
    {
        image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData) // �����Ͱ� ���� ������ ������
    {
        image.color = Color.gray;
    }

    public void OnDrop(PointerEventData eventData) // ���Կ� ������� ��
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
    }


}
