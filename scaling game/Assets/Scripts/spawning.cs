using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject transparentPrefab;
    public GameObject groundPrefab;
    public Vector2 mousepos;

    // Start is called before the first frame update
    void Start()
    {
        mousepos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

    }

    // Update is called once per frame
    void Update()
    {
        
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        transparentPrefab.transform.position = mousepos;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(groundPrefab, mousepos, Quaternion.identity);
        }
    }
}
