using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DragQuiz : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private Transform previousParent;
    private RectTransform rect;
    private CanvasGroup group;

    public TextMeshProUGUI corrextTxt;
    public RectTransform panel;

    private bool isEnd = false;

    public int count = 0;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        if(count > 1 && isEnd == false)
        {
            isEnd = true;
            QuizManager.Instance.collectCount++;
            QuizManager.Instance.CompassCounter();
            QuizManager.Instance.StartCorrectTime(panel);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) // �巡�� ����
    {
        previousParent = transform.parent; // �巡�� �� �θ� Transform ����

        // �巡�� ���� Ui ǥ��
        transform.SetParent(canvas);  // �θ� ĵ������ ����
        transform.SetAsFirstSibling();  // ���� �տ� ���̱� ���� ��ġ ����

        group.alpha = 0.8f;
        group.blocksRaycasts = true; // ���� �⵿ ���ϰ� 
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
        //group.blocksRaycasts = false; // ���� �浹 �����ϰ�

        if(transform.parent.gameObject.tag == transform.tag)
        {
            count++;
            FindObjectsOfType<DragQuiz>();
            foreach(DragQuiz q in FindObjectsOfType<DragQuiz>())
            {
                if(q == this)
                {

                }
                else
                {
                    q.count = this.count;
                }
            }

            Debug.Log("Co");
            StartCoroutine(Correct());
        }
        else
        {
            QuizManager.Instance.StartWrongTime(gameObject);
        }
    }

    public void ResetDrag()
    {
        transform.SetParent(previousParent);

        rect.position = previousParent.GetComponent<RectTransform>().position;
        count = 0;
        //group.blocksRaycasts = true;
        
        //gameObject.transform = previousParent;
    }

    IEnumerator Correct()
    {
        corrextTxt.fontSize = 200;
        corrextTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        corrextTxt.gameObject.SetActive(false);
        corrextTxt.fontSize = 475;
    }

}
