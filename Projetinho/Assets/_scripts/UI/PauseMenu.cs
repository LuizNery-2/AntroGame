using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    public bool isPaused {  get; private set; }
    public GameObject pausePanel;
    
    public string cena;


        void Start()
    {   
        Time.timeScale = 1f;
         isPaused = false; 
        pausePanel.SetActive(isPaused);
     
    }

    
    void Update()
    {
           if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseScreen();
        }
        
    }
    private void PauseScreen()
    {  if (isPaused)
      {  isPaused = false;
         Time.timeScale = 1f;
         pausePanel.SetActive(isPaused);
         Cursor.lockState = CursorLockMode.Locked;
         Cursor.visible = false;
      }
      else
      {   isPaused = true;
          Time.timeScale = 0f;
          pausePanel.SetActive(isPaused);
          Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
      }

    }
    public void BackToHome(){
        SceneManager.LoadScene(cena);
    }
    
}

