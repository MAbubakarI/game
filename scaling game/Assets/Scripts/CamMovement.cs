using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public float speed;
    public float size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        size += Input.mouseScrollDelta.y;
        if (size < 5) size = 5;
        if (size > 20) size = 20;
        transform.position = Vector3.Lerp(transform.position, player.position+offset, speed);
    }
}
