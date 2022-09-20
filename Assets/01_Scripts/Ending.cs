using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Ending : MonoBehaviour
{   
    public Image _compassImage;
    private void Awake() {
        gameObject.SetActive(false);
    }
    public void EndPanel(){
        gameObject.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(_compassImage.DOFillAmount(1f, 2f));

        seq.OnComplete(() => {
            
        });
        

        
    }
}
