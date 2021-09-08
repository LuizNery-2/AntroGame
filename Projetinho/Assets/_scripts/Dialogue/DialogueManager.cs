using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System; 


[Serializable]
public class DialogueManager: MonoBehaviour
{

    [Header("Componentes")]
    [SerializeField] 
    GameObject dialogueObject;
    [SerializeField]
    Image profile;
    [SerializeField]
     TextMeshProUGUI speechText;


    [Header("Settings")]
    [SerializeField]
    float typeSpeed;
    public string [] sentences{get; private set;}
    public int index{get; private set;}
    public bool isSpeaking{get; private set;}
  

    public void SetDialogue(string [] txt, Sprite p)
    {   isSpeaking = true;
        dialogueObject.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        StartCoroutine(TypeSentences());
        
        
    }

    IEnumerator TypeSentences()
    
    {
        
       foreach (char letter in sentences[index].ToCharArray())
       {   
           speechText.text += letter;
           yield return new WaitForSeconds(typeSpeed);
          
           
           
       }     
       
    }

    public void NextSentence(){
       
           
           if (speechText.text == sentences[index])
            {
               if (index < sentences.Length - 1  )
              {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentences());
                }
             else
              {
                speechText.text = "";
                index = 0;
                dialogueObject.SetActive(false);
                isSpeaking = false;
                
               }

            } 
                

           
            
            
    }

    public void DisableDialogue(){

      index = 0;
      speechText.text = "";
      dialogueObject.SetActive(false);
      


    }

     public TextMeshProUGUI GetSpeechText(){

         return speechText;
     }
   
    

}
