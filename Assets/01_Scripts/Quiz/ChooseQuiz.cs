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


    public void Correct()
    {
        Debug.Log("정답");

        StartCoroutine(QuizManager.Instance.CorrectTime(quizPanel));

        QuizManager.Instance.collectCount++;

        QuizManager.Instance.CompassCounter();
    }

    public void Wrong()
    {
        Debug.Log("오답");

        StartCoroutine(QuizManager.Instance.WrongTime(gameObject));
    }

}