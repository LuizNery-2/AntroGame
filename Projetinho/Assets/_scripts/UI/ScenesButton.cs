using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScenesButton : MonoBehaviour
{
    [SerializeField]
    GameObject creditos;
    [SerializeField]
    GameObject creditos1;
    [SerializeField]
    LevelLoader loadLevel;
    [SerializeField]
    string sceneName;
   
    public void scenesButton(){

       loadLevel.LoadNextLevel(sceneName);

    }

    public void CreditosManeger(){
       
      creditos.SetActive(true);
      creditos1.SetActive(false);
       


    }
    
     public void scenesAnimator(){

       loadLevel.LoadNextLevel(sceneName);

    }

    public void scenesNOanim(){

       SceneManager.LoadScene(sceneName);

    }



}
