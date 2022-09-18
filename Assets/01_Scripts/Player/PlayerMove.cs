using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public static PlayerMove Instance = null;

    public float _speed = 10f;
    public Rigidbody2D rigid;
    public Animator ani;


    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
    }

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

    public void StopMove(){
        if(QuizManager.Instance._isPlayerTrigger == true){
            _speed = 0;
        } 

        if(QuizManager.Instance._isPlayerTrigger == false){
            _speed = 10f;
        }
    }
    
    
}
