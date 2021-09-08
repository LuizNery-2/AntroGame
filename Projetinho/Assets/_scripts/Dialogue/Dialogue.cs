using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu]
public class Dialogue: ScriptableObject
{
     [SerializeField]
     Sprite profileSprite;
     [SerializeField]
     string [] speechText;
     [SerializeField]
     bool isPlayer;
     
    

     public Sprite  GetprofileSprite(){

            return profileSprite;
     }

     public string [] GetSpeechText(){
         
           return speechText;
     }
     
     public bool GetIsPlayer(){
          return isPlayer;
     }

    

    
}
