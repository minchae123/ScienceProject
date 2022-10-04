using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public static QuizManager Instance = null;

    public int collectCount = 0;
    public Image fillCompass;
    public bool _isPlayerTrigger;

    public TextMeshProUGUI correctText;

    
    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            collectCount = 10;
        }
    }

    public IEnumerator WrongTime(GameObject panel)
    {   
        Color targetColor = new Color();
        Image color = panel.GetComponent<Image>();

        targetColor = Color.red;
        targetColor.a = 0.5f;
        color.color = targetColor;
        panel.gameObject.transform.DOShakePosition(1, 5f);
        yield return new WaitForSeconds(1f);

        targetColor = new Color(0.23f, 0.3f, 0.33f);
        targetColor.a = 0.5f;
        color.color = targetColor;
        // panel.transform.DOShakePosition(1, 5f);
        // yield return new WaitForSeconds(1f);


        //redPanel.gameObject.SetActive(false);
    }

    public void StartCorrectTime(RectTransform panel){
        
        StartCoroutine(CorrectTime(panel));
    }

    public void StartWrongTime(GameObject panel){
        StartCoroutine(WrongTime(panel));
    }

    public IEnumerator CorrectTime(RectTransform panel)
    {   
        correctText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        correctText.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        
        PopDown(panel);
        QuizManager.Instance._isPlayerTrigger = false;
        PlayerMove.Instance.StopMove();
    }

    void PopDown(RectTransform panel){

        //pl.SetActive(true);
        Debug.Log("작동");
        Sequence seq = DOTween.Sequence();

        seq.Append(panel.transform.DOScale(new Vector3(1.05f, 1.05f), 0.4f));
        seq.Append(panel.transform.DOScale(new Vector3(0, 0), 0.2f));

        seq.OnComplete(() => {
            panel.gameObject.SetActive(false);
        });

        
    }

    public void CompassCounter(){
        if(QuizManager.Instance.collectCount == 0)
            fillCompass.fillAmount = 0;

        if(QuizManager.Instance.collectCount == 1)
            fillCompass.fillAmount = 0.1f;

        if(QuizManager.Instance.collectCount == 2)
            fillCompass.fillAmount = 0.2f;

        if(QuizManager.Instance.collectCount == 3)
            fillCompass.fillAmount = 0.3f;

        if(QuizManager.Instance.collectCount == 4)
            fillCompass.fillAmount = 0.4f;

        if(QuizManager.Instance.collectCount == 5)
            fillCompass.fillAmount = 0.5f;

        if(QuizManager.Instance.collectCount == 6)
            fillCompass.fillAmount = 0.6f;

        if(QuizManager.Instance.collectCount == 7)
            fillCompass.fillAmount = 0.7f;

        if(QuizManager.Instance.collectCount == 8)
            fillCompass.fillAmount = 0.8f;

        if(QuizManager.Instance.collectCount == 9)
            fillCompass.fillAmount = 0.9f;

        if(QuizManager.Instance.collectCount == 10)
            fillCompass.fillAmount = 1;
    }
}
