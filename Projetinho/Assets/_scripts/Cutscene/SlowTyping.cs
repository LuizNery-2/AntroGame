using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SlowTyping : MonoBehaviour
{

    [SerializeField]
     TextMeshProUGUI speechText;


    [Header("Settings")]
    [SerializeField]
    Animator CutSceneAnimator;
    [SerializeField]
    float typeSpeed;
    [SerializeField]
    float loadingSpeed;
    [SerializeField]
    string [] sentences;
    public int index{get; private set;}
    [SerializeField]
    string sceneName;
    [SerializeField]
     LevelLoader NextLevel;

   
    
    void Awake(){

        SetDialogue();
    }

    void Update(){

        if (Input.GetMouseButtonDown(0)){

           NextSentence();

        }
    }

    public void SetDialogue()
    {   
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
                CutSceneAnimator.SetTrigger("StartPT2");
                StartCoroutine(TypeSentences());
                
                
                }
             else
              {
                speechText.text = "";
                index = 0;
                NextLevel.LoadNextLevel(sceneName);
                
                
               }

            }   
            
    }
    


}
