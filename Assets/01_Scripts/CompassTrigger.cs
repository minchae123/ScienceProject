using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CompassTrigger : MonoBehaviour
{   
    public UnityEvent PlayerTrigger;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")){

            gameObject.SetActive(false);
            PlayerTrigger?.Invoke();
            // PlayerTrigger Invoke 시 플레이어 이동 막기 (bool 값으로 관리하기)
        }
    }
}
