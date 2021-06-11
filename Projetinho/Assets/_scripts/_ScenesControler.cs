using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _ScenesControler : MonoBehaviour
{
    
   public void StartScene(){
       SceneManager.LoadScene(1);
   }
   public void IrparaCreditos(){
       SceneManager.LoadScene(2);
   }
   public void Voltar(){
       SceneManager.LoadScene(0);
   }
}
