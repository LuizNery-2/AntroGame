using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocidadeH;
    Vector3 velocidadeV;
    Vector3 velocidadefinal;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    Animator animator;
    public float speed;
    public float alturaMax;
    public float tempo;
    float JumpSpeed;
    float gravidade;
    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingRight.x * -1;
        animator = GetComponent<Animator>();
        gravidade = 2 * alturaMax/ Mathf.Pow(tempo, 2); 
        controller = GetComponent<CharacterController>();
        JumpSpeed = gravidade * tempo;
    }


    private void FixedUpdate() {
        Movimento();

    }

    private void Movimento(){
        
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("Correr", true);
        }
        else
        {
            animator.SetBool("Correr", false);
        }


        if(Input.GetAxis("Horizontal") > 0){
            transform.localScale = facingRight;
            
        }
        else if(Input.GetAxis("Horizontal") < 0){
            transform.localScale = facingLeft;
        }
     
        if(controller.isGrounded){
            velocidadeV = Vector3.down;
        }
        if(Input.GetKey("space") && controller.isGrounded){
            velocidadeV = JumpSpeed * Vector3.up;
            animator.SetBool("pulando", true);
        }
        else if(controller.isGrounded){
            animator.SetBool("pulando", false);
        }
        velocidadeH = speed * Vector3.right * Input.GetAxis("Horizontal");
        velocidadeV += gravidade * Time.deltaTime * Vector3.down;
        velocidadefinal = velocidadeH + velocidadeV;
        controller.Move(velocidadefinal * Time.deltaTime);
        
    }
}
