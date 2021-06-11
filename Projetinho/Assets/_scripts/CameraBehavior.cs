using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField]
    Vector3 camera;
    public Transform player;
    [Range (0,1)]
    public float suavidade;

    void FixedUpdate()
    {
           camera = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
           transform.position = Vector3.Lerp(transform.position ,camera, suavidade);
    }
}
