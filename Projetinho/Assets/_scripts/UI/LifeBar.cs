using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LifeBar : MonoBehaviour
{   [SerializeField]
     player playerLife;

     [SerializeField]
     GameObject lifeBarImage20;
     [SerializeField]
     GameObject lifeBarImage40;
     [SerializeField]
     GameObject lifeBarImage60;
     [SerializeField]
     GameObject lifeBarImage80;
     [SerializeField]
     GameObject lifeBarImage100;
    
     
     void Start(){
         
          if (playerLife.GetPlayerLife() == 100 )
        {   
            
            lifeBarImage20.SetActive(false);
            lifeBarImage40.SetActive(false);
            lifeBarImage60.SetActive(false);
            lifeBarImage80.SetActive(false);
            lifeBarImage100.SetActive(true);
         
        }
       
     } 

     void Update(){
         LifeBarChange();
     }
     private void LifeBarChange()
     {  
        switch (playerLife.GetPlayerLife())
        {   case 80:
            lifeBarImage20.SetActive(false);
            lifeBarImage40.SetActive(false);
            lifeBarImage60.SetActive(false);
            lifeBarImage80.SetActive(true);
            lifeBarImage100.SetActive(false);
            break;
             case 60:
            lifeBarImage20.SetActive(false);
            lifeBarImage40.SetActive(false);
            lifeBarImage60.SetActive(true);
            lifeBarImage80.SetActive(false);
            lifeBarImage100.SetActive(false);
            break;
             case 40:
            lifeBarImage20.SetActive(false);
            lifeBarImage40.SetActive(true);
            lifeBarImage60.SetActive(false);
            lifeBarImage80.SetActive(false);
            lifeBarImage100.SetActive(false);
            break;
             case 20:
            lifeBarImage20.SetActive(true);
            lifeBarImage40.SetActive(false);
            lifeBarImage60.SetActive(false);
            lifeBarImage80.SetActive(false);
            lifeBarImage100.SetActive(false);
            break;
              case 100:
            lifeBarImage20.SetActive(false);
            lifeBarImage40.SetActive(false);
            lifeBarImage60.SetActive(false);
            lifeBarImage80.SetActive(false);
            lifeBarImage100.SetActive(true);
            break;
            case 0:
            lifeBarImage20.SetActive(false);
            lifeBarImage40.SetActive(false);
            lifeBarImage60.SetActive(false);
            lifeBarImage80.SetActive(false);
            lifeBarImage100.SetActive(false);
            break;
            
        }
    

     }
}
