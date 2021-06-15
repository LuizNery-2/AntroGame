using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    Vector3 velocidade;
    public float speed;
    Vector3 velocidadeV;
    Vector3 velocidadefinal;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    Vector3 enemy;
    CharacterController controller;
    private float initialPosition;
    private void Start() {
        initialPosition = transform.position.x;
        controller = GetComponent<CharacterController>();
        velocidadeV = Vector3.down;
        facingLeft = transform.localScale;
        facingRight = transform.localScale;
        facingLeft.x = facingRight.x * -1;
        
    }
    void FixedUpdate()
    { MovimentoIni();
       
    }
       private void MovimentoIni()
    {      velocidade = speed * Vector3.right * Time.deltaTime;
           velocidadefinal = velocidade + velocidadeV;
            controller.Move(velocidadefinal);
        
        if(transform.position.x - initialPosition > 2f){
            speed *= -1;
             transform.localScale = facingLeft;
        }
        else if(transform.position.x - initialPosition < -2f){
              speed *= -1;
              transform.localScale = facingRight;
                 
                 
            
        }
       
        
    }
}
