using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelLoader : MonoBehaviour
{

    [SerializeField]
    Animator transition;
    [SerializeField]
    float transitionTime;
   
    
      
    public void LoadNextLevel(string cena){
         
        
         if(transition != null){

          StartCoroutine(LoadLevel(cena));

         }
         else{

             SceneManager.LoadScene(cena); 
         }
         
     
    }


    IEnumerator LoadLevel(string cena){
        
        
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(cena);
       

    }
    
}
