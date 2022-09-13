using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CompassTrigger : MonoBehaviour
{
    public UnityEvent PlayerTrigger;

    [SerializeField]
    private int count = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(CompareTag("Player")){
            PlayerTrigger?.Invoke();
            count++;
            Debug.Log(count);
        }
    }
}
