using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public CustomButton cB;
    [Header("Components")]  
    public GameObject dialogueBox;
    public Text Dialogue;
    public Text ActorName;
    public float typingSpeed;

    private string[] sentence;
    private int index;
    public void Start(){
        cB = FindObjectOfType<CustomButton>();
    }
    public void Speech(string[] txt, string ActorName){
        dialogueBox.SetActive(true);
        this.ActorName.text = ActorName;
        sentence = txt;
        StartCoroutine(TypeFrase());
    }    
    public void NextSentence(){
        if(Dialogue.text == sentence[index]){
            if(index < sentence.Length - 1){
                index++;
                Dialogue.text = "";
                StartCoroutine(TypeFrase());
            }else{
            Dialogue.text = "";
            index = 0;
            dialogueBox.SetActive(false);
        }
        }

    }
    IEnumerator TypeFrase(){
        foreach (char letter in sentence[index].ToCharArray())
        {
            Dialogue.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
