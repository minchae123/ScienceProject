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

    public void OnBeginDrag(PointerEventData eventData) // �巡�� ����
    {
        previousParent = transform.parent; // �巡�� �� �θ� Transform ����

        // �巡�� ���� Ui ǥ��
        transform.SetParent(canvas);  // �θ� ĵ������ ����
        transform.SetAsFirstSibling();  // ���� �տ� ���̱� ���� ��ġ ����

        group.alpha = 0.6f;
        group.blocksRaycasts = false; // ���� �⵿ ���ϰ� 
    }

    public void OnDrag(PointerEventData eventData) // �巡�� ���϶�
    {
        rect.position = eventData.position; // ui ��ġ�� ���콺 ��ġ�� 
    }

    public void OnEndDrag(PointerEventData eventData) // �巡�� ���� �Ҷ� 1�� ȣ��
    {
        if(transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        group.alpha = 1f;
        group.blocksRaycasts = false; // ���� �浹 �����ϰ�
    }




}
