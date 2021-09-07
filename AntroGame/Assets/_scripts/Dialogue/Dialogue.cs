using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    
    public DialogueController dc;
    bool onRadius;
    [Header("Dialogo com o Pesquisador:")]
    public string[] txt;
    public string actorName;
    [Header("Typing Configs")]
    public float radius;
    public LayerMask playerLayer;
    private void Start() {
        dc = FindObjectOfType<DialogueController>();
    }
    //INTERAÇÕES//
    private void FixedUpdate() {
        Interact();
    }
    private void Update() {
            if(Input.GetKeyDown(KeyCode.E) && onRadius){
                dc.Speech(txt, actorName);
            }
    }
    private void Interact(){
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, playerLayer);
        if(hit != null){
            onRadius = true;
        }else{
            onRadius = false;
        }
    }
}
