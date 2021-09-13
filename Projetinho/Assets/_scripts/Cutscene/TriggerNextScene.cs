using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextScene : MonoBehaviour
{
    [SerializeField]
    string cena;
    [SerializeField]
    LevelLoader NextLevel;
 
  private void OnTriggerEnter(Collider other) {
      if (other.tag == "Player")
      {
           NextLevel.LoadNextLevel(cena);
           Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;
      }

  }

}
