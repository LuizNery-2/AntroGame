using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
        
{       

       private void OnTriggerEnter(Collider other) {
            

            Debug.Log("Trigger ativado: " + other.name);
            IDamageable damageable = other.GetComponent<IDamageable>();
            if(damageable != null){
                
                damageable.TakeDamage();
            }
       }
}
