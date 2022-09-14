using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragQuiz : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private Transform previousParent;
    private RectTransform rect;
    private CanvasGroup group;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData) // 드래그 시작
    {
        previousParent = transform.parent; // 드래그 전 부모 Transform 저장

        // 드래그 중인 Ui 표시
        transform.SetParent(canvas);  // 부모 캔버스로 설정
        transform.SetAsFirstSibling();  // 가장 앞에 보이기 위해 위치 조정

        group.alpha = 0.6f;
        group.blocksRaycasts = false; // 광선 출동 못하게 
    }

    public void OnDrag(PointerEventData eventData) // 드래그 중일때
    {
        rect.position = eventData.position; // ui 위치를 마우스 위치로 
    }

    public void OnEndDrag(PointerEventData eventData) // 드래그 종료 할때 1번 호출
    {
        if(transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        group.alpha = 1f;
        group.blocksRaycasts = false; // 광선 충돌 가능하게
    }




}
