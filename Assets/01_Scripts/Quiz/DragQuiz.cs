using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

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
    public int wrongcount = 0;

    public Image im;
    public Image pa;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();

        previousParent = transform.parent; // �巡�� �� �θ� Transform ����
    }

    private void Update()
    {
        if(count == 2 && isEnd == false)
        {
            isEnd = true;
            QuizManager.Instance.collectCount++;
            QuizManager.Instance.CompassCounter();
            QuizManager.Instance.StartCorrectTime(panel);
            count = 0;
            wrongcount = 0;
        }

        if(wrongcount == 2)
        {
            QuizManager.Instance.StartWrongTime(pa.gameObject);
            ResetDrag();
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
            group.blocksRaycasts = false;
        }
        else if(transform.parent.gameObject.tag != transform.tag)
        {
            wrongcount++;
            foreach (DragQuiz q in FindObjectsOfType<DragQuiz>())
            {
                if (q == this)
                {

                }
                else
                {
                    q.wrongcount = this.wrongcount;
                }
            }

            StartCoroutine(Wrong(im));
        }
    }

    public void ResetDrag()
    {
        transform.SetParent(previousParent);

        rect.position = previousParent.GetComponent<RectTransform>().position;
        count = 0;
        wrongcount = 0;
        group.blocksRaycasts = true;
        previousParent = transform.parent;
    }

    IEnumerator Correct()
    {
        corrextTxt.fontSize = 200;
        corrextTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        corrextTxt.gameObject.SetActive(false);
        corrextTxt.fontSize = 475;
    }

    IEnumerator Wrong(Image im)
    {
        Color targetColor = new Color();
        Image color = im.GetComponent<Image>();

        //targetColor = Color.red;
        targetColor = new Color(1, 0.5f, 0.5f);
        color.color = targetColor;
        im.gameObject.transform.DOShakePosition(0.5f, 5f);
        yield return new WaitForSeconds(0.2f);

        targetColor = Color.white;
        color.color = targetColor;
    }

}
