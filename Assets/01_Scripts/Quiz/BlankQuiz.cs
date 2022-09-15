using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BlankQuiz : MonoBehaviour
{
    [SerializeField] string text;
    public TMP_InputField inputField;

    public RectTransform quizPanel;

    private void Start()
    {
        inputField.ActivateInputField();
    }

    public void CheckText(string txt)
    {
            if (text == txt)
            {   
                QuizManager.Instance.collectCount++;
                QuizManager.Instance.CompassCounter();
                
                QuizManager.Instance.StartCorrectTime(quizPanel);
                Debug.Log("자살할게");
            }
            else
            {
                Debug.Log("불일치");
                QuizManager.Instance.StartWrongTime(gameObject);
            }
        
    }
}
