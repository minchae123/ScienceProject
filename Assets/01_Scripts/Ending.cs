using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Ending : MonoBehaviour
{   
    public Image _compassImage;

    public GameObject pa;
    bool istouch = false;

    private void Awake() {
        _compassImage.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && QuizManager.Instance.collectCount == 10)
        {
            Debug.Log("^0^");
            EndPanel();
        }
        else if(istouch == false)
        {
            istouch = true;
            Debug.Log("-0-");
            StartCoroutine(NOTime(pa));
        }
    }

    public void EndPanel(){
        _compassImage.gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        //seq.Append(_compassImage.DOFillAmount(1f, 2f));

        seq.OnComplete(() => {
            
        });
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
        istouch = false;
    }
}
