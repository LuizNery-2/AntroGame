using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour , IDamageable
{     
      public event Action DamageEvent;
      player playerLife;
      GameObject player;
      [SerializeField]
      AudioSource damageSound;

       private void Awake() 
       {  playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
         
       }
      public void TakeDamage(int damage)
      {      
           
                    if (damageSound != null)
                   {
                       damageSound.Play();
                   }
                   if (playerLife.GetIsInvencible())
                   {
                     playerLife.SetPlayerLife(damage);
                   }
                   
                   DamageEvent.Invoke();
               
              
      }   
}
