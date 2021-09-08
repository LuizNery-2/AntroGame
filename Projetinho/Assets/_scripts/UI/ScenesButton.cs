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

   
    public string sceneName;
    public void scenesButton(){

      SceneManager.LoadScene(sceneName);

    }

    public void CreditosManeger(){
       
      creditos.SetActive(true);
      creditos1.SetActive(false);
       


    }




}
