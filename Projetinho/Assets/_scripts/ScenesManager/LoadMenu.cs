using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMenu : MonoBehaviour
{
   [SerializeField]
   string sceneName;
   [SerializeField]
   LevelLoader NextLevel;

   void Start()
   {
       StartCoroutine(LoadMenuScene(sceneName));

   }

   IEnumerator LoadMenuScene(string sceneName){

      yield return new WaitForSeconds(3f);
      NextLevel.LoadNextLevel(sceneName);

   }
 
}
