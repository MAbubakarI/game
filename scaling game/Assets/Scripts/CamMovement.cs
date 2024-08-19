using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamMovement : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public float speed;
    public float size;
    public Camera m_OrthographicCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            size -= Input.mouseScrollDelta.y;
        }
        if (size < 5) size = 5;
        if (size > 20) size = 20;
        m_OrthographicCamera.orthographicSize = size;
        transform.position = Vector3.Lerp(transform.position, player.position+offset, speed*Time.deltaTime);
    }
}
