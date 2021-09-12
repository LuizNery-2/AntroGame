using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour, ITalkable
{
   
    private DialogueManager dm;
   [SerializeField]
    private Dialogue[] dialogue;
   [SerializeField]
    private GameObject playerDialogue;
    [SerializeField]
    private GameObject NpcDialogue;
    int contador;


   public void SetTalk() {
       
         
         
            
                  if(dialogue[contador].GetIsPlayer()) {

                     dm = playerDialogue.GetComponent<DialogueManager>();
                     dm.SetDialogue(dialogue[contador].GetSpeechText(), dialogue[contador].GetprofileSprite());

                  }
                  else
                  { dm = NpcDialogue.GetComponent<DialogueManager>();
                    dm.SetDialogue(dialogue[contador].GetSpeechText(), dialogue[contador].GetprofileSprite());
                  }
                     
               
            
             
         
     

   }


   public void DisableTalk() {

     
         dm.DisableDialogue();
         dm = null;
         contador = 0;
         
     
       
   }

      
    
    public void NextSpeaker(){
             
             
             
             if (dm.GetSpeechText().text == dm.sentences[dm.index])
            {
                dm.NextSentence();
                 if(!dm.isSpeaking && contador < dialogue.Length - 1 ){
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
