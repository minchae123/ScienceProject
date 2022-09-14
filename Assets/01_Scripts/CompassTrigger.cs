using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CompassTrigger : MonoBehaviour
{
    public UnityEvent PlayerTrigger;

    public Image compass;
    public UnityEvent CompassColl;

    public int qCount = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(CompareTag("Player")){
            PlayerTrigger?.Invoke();
            qCount++;
            Debug.Log(qCount);
            CompassCounter();
        }
    }

    void CompassCounter(){
        if(qCount == 0)
            compass.fillAmount = 0;

        if(qCount == 1)
            compass.fillAmount = 0.1f;

        if(qCount == 2)
            compass.fillAmount = 0.2f;

        if(qCount == 3)
            compass.fillAmount = 0.3f;

        if(qCount == 4)
            compass.fillAmount = 0.4f;

        if(qCount == 5)
            compass.fillAmount = 0.5f;

        if(qCount == 6)
            compass.fillAmount = 0.6f;

        if(qCount == 7)
            compass.fillAmount = 0.7f;

        if(qCount == 8)
            compass.fillAmount = 0.8f;

        if(qCount == 9)
            compass.fillAmount = 0.9f;

        if(qCount == 10)
            compass.fillAmount = 1;
            CompassColl?.Invoke();
        
    }

    
}
