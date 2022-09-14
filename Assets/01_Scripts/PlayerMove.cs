using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;
    public Rigidbody2D rigid;
    public Animator ani;

    void Update()
    {
        Move();
    }

    private void Move(){
        float hori = Input.GetAxisRaw("Horizontal");
        float verti = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(hori, verti);
        rigid.velocity = dir.normalized * _speed;

        ani.SetFloat("Horizontal", rigid.velocity.x);
        ani.SetFloat("Vertical", rigid.velocity.y);
    }
    
    private void OnTriggerEnter(Collider other) {
        
    }
}
