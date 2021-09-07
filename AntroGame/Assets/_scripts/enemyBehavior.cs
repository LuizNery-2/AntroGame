using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(IDamageable))]
public class enemyBehavior : MonoBehaviour
{
    [SerializeField]
    float PatrolTime = 3f;
    IDamageable damageable;
    Rigidbody rb;


    public float speed;
    private Vector3 facingRight;
    private Vector3 facingLeft;
  
    private float initialPosition;
    private void Start() {
        initialPosition = transform.position.x;
        rb = GetComponent<Rigidbody>();
        damageable = GetComponent<IDamageable>();
        facingLeft = transform.eulerAngles;
        facingRight = transform.eulerAngles;
        facingLeft.y = facingRight.y + 180;
        damageable.DamageEvent+= OnDeath;
        StartCoroutine(MovimentoIni());
    }

    void FixedUpdate()
    { 
       
    }
 

    private void OnDestroy(){
          damageable.DamageEvent -= OnDeath;
    }

    private void OnDeath(){
        
        Destroy(gameObject);
          
    }

    private IEnumerator MovimentoIni()
    {
      while (true)
      {
       rb.velocity = new Vector3(speed, 0, 0);
       transform.eulerAngles = facingRight;
       yield return new WaitForSeconds(PatrolTime);
       rb.velocity = new Vector3(speed*-1, 0, 0);
       transform.eulerAngles = facingLeft;  
       yield return new WaitForSeconds(PatrolTime); 
       rb.velocity = new Vector3(speed*-1, 0, 0);
       transform.eulerAngles = facingRight; 
      }
         
     
    }

}
