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
    }

    public void OnPointerEnter(PointerEventData eventData) // 내부로 들어갔을 때
    {
        image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData) // 포인터가 슬롯 영역을 나갈때
    {
        image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData) // 슬롯에 드롭했을 때
    {
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
    }


}
