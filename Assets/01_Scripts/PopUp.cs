using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopUp : MonoBehaviour
{   
    [SerializeField] GameObject panel;
    public GameObject pl;

    //public GameObject reason;

    public void PopUpPanel()
    {
        //pl.SetActive(false);
        panel.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(panel.transform.DOScale(new Vector3(1.05f, 1.05f), 0.4f));
        seq.Append(panel.transform.DOScale(new Vector3(1f, 1f), 0.2f));
    }

    public void PopUpPanel2()
    {
        //pl.SetActive(false);
        //reason.SetActive(true);

        Sequence seq = DOTween.Sequence();

        seq.Append(panel.transform.DOScale(new Vector3(1.05f, 1.05f), 0.4f));
        seq.Append(panel.transform.DOScale(new Vector3(1f, 1f), 0.2f));
    }
}
