using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private Transform targetTr; // 이동될 UI

    private Vector2 startingPoint;
    private Vector2 moveBegin;
    private Vector2 moveOffset;

    private Vector2 startPos;

    private void Awake()
    {
        // 이동 대상 UI를 지정하지 않은 경우, 자동으로 부모로 초기화
        if (targetTr == null)
            targetTr = transform.parent;
        startPos = targetTr.transform.position;
    }

    private void Update()
    {

    }

    // 드래그 시작 위치 지정
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        startingPoint = targetTr.position;
        moveBegin = eventData.position;
    }

    // 드래그 : 마우스 커서 위치로 이동
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - moveBegin;
        targetTr.position = startingPoint + moveOffset;
    }

    public void Pos1()
    {
       
    }

    public void ResetDrag()
    {
        transform.position = startPos;
    }

}
