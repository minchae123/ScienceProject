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

    public int quizCount = 0;
    public int collectCount = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){

            gameObject.SetActive(false);
            Debug.Log("닿음");
            PlayerTrigger?.Invoke();
            quizCount++;
            Debug.Log($"퀴즈 {quizCount}개");
            
        }
    }

    void CompassCounter(){
        if(collectCount == 0)
            compass.fillAmount = 0;

        if(collectCount == 1)
            compass.fillAmount = 0.1f;

        if(collectCount == 2)
            compass.fillAmount = 0.2f;

        if(collectCount == 3)
            compass.fillAmount = 0.3f;

        if(collectCount == 4)
            compass.fillAmount = 0.4f;

        if(collectCount == 5)
            compass.fillAmount = 0.5f;

        if(collectCount == 6)
            compass.fillAmount = 0.6f;

        if(collectCount == 7)
            compass.fillAmount = 0.7f;

        if(collectCount == 8)
            compass.fillAmount = 0.8f;

        if(collectCount == 9)
            compass.fillAmount = 0.9f;

        if(collectCount == 10)
            compass.fillAmount = 1;
            CompassColl?.Invoke();
        
    }

    
}
