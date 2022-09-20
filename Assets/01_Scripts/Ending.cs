using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{   
    public Image _compassImage;
    public Text _endingText;

    public GameObject _endingPanel;
    public GameObject _endingPanel2;
    bool isTouch = false;

    public float ti = 0;
    bool isFinsih = false;
    
    private void Awake() {
        _compassImage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(isFinsih == true)
        {
            if (ti <= 1)
            {
                ti += Time.deltaTime * 1.5f;
                _compassImage.fillAmount = ti;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && QuizManager.Instance.collectCount == 10)
        {
            Debug.Log("^0^");
            EndPanel();
        }
        else if(isTouch == false)
        {
            isTouch = true;
            Debug.Log("-0-");
            StartCoroutine(NOTime(_endingPanel2));
        }
    }

    public void EndPanel(){

        Sequence seq = DOTween.Sequence();

        _endingPanel.gameObject.SetActive(true);
        seq.Append(_endingPanel.transform.DOScale(new Vector3(1.05f, 1.05f), 0.4f));
        seq.Append(_endingPanel.transform.DOScale(new Vector3(1f, 1f), 0.2f));

        seq.Append(_endingText.DOText("당신을 \" 전 류 의 자 기 작 용  【 마 스 터 】 \" 로 임명하겠다.", 3));
        _compassImage.gameObject.SetActive(true);
        isFinsih = true;
        //seq.Append(_compassImage.DOFillAmount(1f, 2f));
        

    }

    public IEnumerator NOTime(GameObject panel)
    {
        panel.gameObject.SetActive(true);
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
        panel.gameObject.SetActive(false);
        isTouch = false;
    }
}
