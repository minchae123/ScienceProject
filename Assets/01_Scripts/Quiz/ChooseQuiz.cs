using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ChooseQuiz : MonoBehaviour
{
    public Image panel;
    public TextMeshProUGUI collextTxt; 

    public void Correct()
    {
        Debug.Log("Á¤´ä");

        StartCoroutine(CorrectTime());
    }

    public void Wrong()
    {
        Debug.Log("¶¯¶¯");

        StartCoroutine(WrongTime());
    }

    IEnumerator WrongTime()
    {
        Color targetColor = new Color();
        targetColor = Color.red;
        targetColor.a = 0.65f;
        panel.color = targetColor;
        panel.transform.DOShakePosition(1, 5f);
        yield return new WaitForSeconds(1f);

        targetColor = new Color(0.23f, 0.3f, 0.33f);
        targetColor.a = 0.65f;
        panel.color = targetColor;
    }

    IEnumerator CorrectTime()
    {
        collextTxt.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        collextTxt.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        panel.gameObject.SetActive(false);
    }
}