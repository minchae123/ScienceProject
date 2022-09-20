using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompassTxt : MonoBehaviour
{
    public TextMeshProUGUI tx;

    void Start()
    {
        
    }

    void Update()
    {
        tx.text = "모은 나침반 : \n" + QuizManager.Instance.collectCount + "/" + "10";
    }
}
