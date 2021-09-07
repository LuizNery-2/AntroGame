using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour , IDamageable
{     
      public event Action DamageEvent;
      private int life;
      public void TakeDamage()
      {
              DamageEvent.Invoke();
      }   
}
