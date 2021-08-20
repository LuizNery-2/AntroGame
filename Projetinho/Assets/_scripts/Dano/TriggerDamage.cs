using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
        
{       

    [SerializeField]

         private int damage = 10;

      

       private void OnTriggerEnter(Collider other) {
            

            Debug.Log("Trigger ativado: " + other.name);
            IDamageable damageable = other.GetComponent<IDamageable>();
            if(damageable != null){
                
                damageable.TakeDamage(damage);
            }
       }
}
