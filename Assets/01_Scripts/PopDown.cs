using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PopDown : MonoBehaviour
{
     [SerializeField] GameObject panel;

     void PopDownPanel(){

        Sequence seq = DOTween.Sequence();

        seq.Append(panel.transform.DOScale(new Vector3(1.05f, 1.05f), 0.4f));
        seq.Append(panel.transform.DOScale(new Vector3(0, 0), 0.2f));

        panel.SetActive(false);
     }
}
