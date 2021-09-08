using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour 
{
   [SerializeField]
    DialogueManager dm;
   [SerializeField]
    Dialogue[] dialogue;
   [SerializeField]
    GameObject playerDialogue;
    [SerializeField]
    GameObject NpcDialogue;
    int contador; 

   


      

   private void OnTriggerEnter(Collider other) {
       
         
         
             if (other.tag == "Player")
             { 
                  if(dialogue[contador].GetIsPlayer()) {

                     dm = playerDialogue.GetComponent<DialogueManager>();
                     dm.SetDialogue(dialogue[contador].GetSpeechText(), dialogue[contador].GetprofileSprite());

                  }
                  else
                  { dm = NpcDialogue.GetComponent<DialogueManager>();
                    dm.SetDialogue(dialogue[contador].GetSpeechText(), dialogue[contador].GetprofileSprite());
                  }
                     
               
             }
             
         
     

   }


   private void OnTriggerExit(Collider other) {

       if (other.tag == "Player")
     {
         dm.DisableDialogue();
     }
       
   }

      
    
    public void NextSpeaker(){
             
             
             
             if (dm.GetSpeechText().text == dm.sentences[dm.index])
            {
                dm.NextSentence();
                 if(!dm.isSpeaking){
                  contador++;
                      if(dialogue[contador].GetIsPlayer()) 
                      {

                     dm = playerDialogue.GetComponent<DialogueManager>();
                     dm.SetDialogue(dialogue[contador].GetSpeechText(), dialogue[contador].GetprofileSprite());
                     

                     }
                  else
                   {
                    dm = NpcDialogue.GetComponent<DialogueManager>();
                    dm.SetDialogue(dialogue[contador].GetSpeechText(), dialogue[contador].GetprofileSprite());
                    
                   }  
                      
              
        
                }

            } 
            
           
    }

}
