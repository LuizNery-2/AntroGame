using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{  [SerializeField]GameObject VirtualCam1;  
   [SerializeField]GameObject VirtualCam2; 

   private bool chooseCamera1;
   
   
   void Awake()
   {    chooseCamera1 = false;
        VirtualCam2.SetActive(false);
   }
   
   
   
   private void OnTriggerEnter(Collider other) {
       
        if (chooseCamera1)
       {
           VirtualCam1.SetActive(true);
           VirtualCam2.SetActive(false);
           chooseCamera1 = false; 
       }
       else if (other.tag == "Player")
       { 
           VirtualCam1.SetActive(false);
           VirtualCam2.SetActive(true);  
           chooseCamera1 = true;  
       
       }
      

   }
}
