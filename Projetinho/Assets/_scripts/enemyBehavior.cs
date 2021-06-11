using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    Vector3 velocidade;
    public float speed;
    Vector3 velocidadeV;
    Vector3 velocidadefinal;

    Vector3 enemy;
    CharacterController controller;
    private void Start() {
        controller = GetComponent<CharacterController>();
        velocidadeV = Vector3.down;
    }
    void FixedUpdate()
    {
        if(player.position.x - transform.position.x >= 0 && player.position.x - transform.position.x <=5){
        velocidade = speed * Vector3.right * Time.deltaTime;  
        velocidadefinal = velocidade + velocidadeV; 
        controller.Move(velocidadefinal);
        }
        else if(player.position.x - transform.position.x >= -5 && player.position.x - transform.position.x < 0){
        velocidade = speed * Vector3.left * Time.deltaTime;
        velocidadefinal = velocidade + velocidadeV;
            controller.Move(velocidadefinal);
        }
        }

}
