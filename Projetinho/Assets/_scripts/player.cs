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
     int life;
    [SerializeField]
    SpriteRenderer playerSprite; 
    bool IsInvencible = true;
    void Start()
    {  
         life = 100;
        facingRight = transform.eulerAngles;
        facingLeft = transform.eulerAngles;
        facingLeft.y = facingRight.y + 180;
        playerSprite = GetComponent<SpriteRenderer>();
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
        if (IsInvencible)
        {
         
         StartCoroutine(DamageMaker());

         if (life <= 0)
         {
            enabled = false;
             animator.enabled = false;
             StartCoroutine(LoseWindow());
         }
            
        }
        

        UnityEngine.Debug.Log("Tomei dano!!");
    }
    
   private IEnumerator LoseWindow()
   {
      yield return new WaitForSeconds(LoseTime);
      SceneManager.LoadScene("Derrota");
   } 
     private IEnumerator DamageMaker(){
         
        IsInvencible = false;

         for (float i = 0; i < 0.5f; i += 0.1f)      
        {   
            playerSprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            playerSprite.enabled = true;
            yield return new WaitForSeconds(0.1f);


        }
       IsInvencible = true; 


     }

     public int SetPlayerLife(int a)
     {
          life -= a;
          return life;
     }

     public int GetPlayerLife(){

         return life;
     }

}    
