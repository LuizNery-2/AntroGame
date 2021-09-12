using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTalk : MonoBehaviour
{   
    ITalkable talk;
    private void OnTriggerEnter(Collider other) {
        
           talk = other.GetComponent<ITalkable>();
           if (talk != null)
           {
              talk.SetTalk();

           }
           
    }
    void OnTriggerExit() {
    
      talk.DisableTalk();   

    }

    public void NextTalk(){


        talk.NextSpeaker();
    }

}
