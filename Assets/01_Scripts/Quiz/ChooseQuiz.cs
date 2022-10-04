using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ChooseQuiz : MonoBehaviour
{
    public static ChooseQuiz Instance = null;

    public RectTransform quizPanel;

    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }

    public GameObject reason;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //reason.gameObject.SetActive(false);
            Destroy(reason);
        }
    }

    public void Correct()
    {
        Debug.Log("정답");

        //StartCoroutine(QuizManager.Instance.CorrectTime(quizPanel));
        StartCoroutine(Reason());
        QuizManager.Instance.collectCount++;

        QuizManager.Instance.CompassCounter();
    }

    public void Wrong()
    {
        Debug.Log("오답");

        StartCoroutine(QuizManager.Instance.WrongTime(gameObject));
    }

    IEnumerator Reason()
    {
        StartCoroutine(QuizManager.Instance.CorrectTime(quizPanel));
        yield return new WaitForSeconds(2.5f);

        reason.gameObject.SetActive(true);
        Debug.Log(1);
       
           
        
        Debug.Log(12);
        //Destroy(reason);
    }

}