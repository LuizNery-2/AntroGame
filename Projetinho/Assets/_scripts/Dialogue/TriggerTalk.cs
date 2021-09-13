using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerTalk : MonoBehaviour
{   
    ITalkable talk;
    private void OnTriggerEnter(Collider other) {
        
           talk = other.GetComponent<ITalkable>();
           if (talk != null)
           {  Cursor.visible = true;
              Cursor.lockState = CursorLockMode.None;
              talk.SetTalk();

           }
           
    }
    void OnTriggerExit() {
    
      if (talk != null)
      {
          talk.DisableTalk(); 
          Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
      }  

    }


    public void NextTalk(){

       Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
        talk.NextSpeaker();
    }

}
