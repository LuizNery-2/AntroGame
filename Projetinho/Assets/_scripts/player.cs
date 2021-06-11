using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocidadeH;
    Vector3 velocidadeV;
    Vector3 velocidadefinal;
    Animator animator;
    public float speed;
    public float alturaMax;
    public float tempo;
    float JumpSpeed;
    float gravidade;
    void Start()
    {
        animator = GetComponent<Animator>();
        gravidade = 2 * alturaMax/ Mathf.Pow(tempo, 2); 
        controller = GetComponent<CharacterController>();
        JumpSpeed = gravidade * tempo;
    }


    private void FixedUpdate() {
        if(Input.GetAxis("Horizontal") < 0){
            animator.SetBool("esquerda", true);
        }
        else if(Input.GetAxis("Horizontal") > 0){
            animator.SetBool("direita", true);
        }
        else if(Input.GetAxis("Horizontal") < 0.02 && Input.GetAxis("Horizontal") > -0.02 ){
            animator.SetBool("direita", false);
            animator.SetBool("esquerda", false);
        }
        if(controller.isGrounded){
            velocidadeV = Vector3.down;
        }
        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded){
            velocidadeV = JumpSpeed * Vector3.up;
        }
        velocidadeH = speed * Vector3.right * Input.GetAxis("Horizontal");
        if(Input.GetAxis("Horizontal") < 0){

        }
        velocidadeV += gravidade * Time.deltaTime * Vector3.down;
        velocidadefinal = velocidadeH + velocidadeV;
        controller.Move(velocidadefinal * Time.deltaTime);
        
    }
}
