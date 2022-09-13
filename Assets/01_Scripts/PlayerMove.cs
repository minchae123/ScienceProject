using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;

    void Update()
    {
        Move();
    }

    private void Move(){
        float hori = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");

        transform.Translate(new Vector3(hori, verti, 0).normalized * _speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter(Collider other) {
        
    }
}
