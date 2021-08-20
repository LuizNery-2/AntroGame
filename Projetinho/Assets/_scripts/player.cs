using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[RequireComponent(typeof(IDamageable))]
public class player : MonoBehaviour
{   
    [SerializeField]GameObject weaponObject;
    public IWeapon weapon {get; private set; }
    
    IDamageable damageable;
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
        damageable = GetComponent<IDamageable>();
        if (weaponObject != null)
        {
           weapon = weaponObject.GetComponent<IWeapon>();
           
        }
        damageable.DamageEvent += OnDamage;
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
        
         if(Input.GetKey(KeyCode.H))
        {
           weapon.Attack();
           
        }
         animator.SetBool("Atacando", weapon.IsAttacking);
       
    }


   private void OnDestroy(){
       if(damageable != null)
       {    
            damageable.DamageEvent -= OnDamage;
       }
       
   }

    private void  OnDamage()
    {   
        enabled = false;
        animator.SetBool("pulando", false);
        animator.SetBool("Correr", false);
        

        UnityEngine.Debug.Log("Tomei dano!!");
    }
    
 
}
