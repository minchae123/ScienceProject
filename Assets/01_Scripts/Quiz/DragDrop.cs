using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField]
    private Transform targetTr; // �̵��� UI

    private Vector2 startingPoint;
    private Vector2 moveBegin;
    private Vector2 moveOffset;

    private Vector2 startPos;

    private void Awake()
    {
        // �̵� ��� UI�� �������� ���� ���, �ڵ����� �θ�� �ʱ�ȭ
        if (targetTr == null)
            targetTr = transform.parent;
        startPos = targetTr.transform.position;
    }

    private void Update()
    {
        Pos1();
    }

    // �巡�� ���� ��ġ ����
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        startingPoint = targetTr.position;
        moveBegin = eventData.position;
    }

    // �巡�� : ���콺 Ŀ�� ��ġ�� �̵�
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        moveOffset = eventData.position - moveBegin;
        targetTr.position = startingPoint + moveOffset;
    }

    public void Pos1()
    {
        float distance = Vector3.Distance(transform.position, targetTr.position);

        if (distance < 0.5f)
        {
            gameObject.transform.SetParent(targetTr);
            transform.position = targetTr.position;
        }
    }
}
