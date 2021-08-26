using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    [SerializeField] 
    private float LoseTime;
    
    void Start()
    {    
        facingRight = transform.eulerAngles;
        facingLeft = transform.eulerAngles;
        facingLeft.y = facingRight.y + 180;
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
            transform.eulerAngles = facingRight;
            
        }
        else if(Input.GetAxis("Horizontal") < 0){
            transform.eulerAngles = facingLeft;
        }
     
        if(controller.isGrounded){
            velocidadeV = Vector3.down;
        }
        if(Input.GetKey("space") && controller.isGrounded || Input.GetKey(KeyCode.W) && controller.isGrounded){
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
        animator.enabled = false;
        StartCoroutine(LoseWindow());

        UnityEngine.Debug.Log("Tomei dano!!");
    }
    
   private IEnumerator LoseWindow()
   {
      yield return new WaitForSeconds(LoseTime);
      SceneManager.LoadScene("Derrota");
   } 
}    
