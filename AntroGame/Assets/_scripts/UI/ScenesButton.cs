using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ScenesButton : MonoBehaviour
{
    public string sceneName;
    public void scenesButton(){

      SceneManager.LoadScene(sceneName);

    }

}
