using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class spawning : MonoBehaviour
{
    public GameObject transparentPrefab;
    public GameObject groundPrefab;
    public Vector2 mousepos;
    public float size;
    public bool onMenu;

    public bool win;
    public int winheight = 50;//game ends(can change depending on map height)
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        onMenu = true; 
        mousepos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > winheight)
        {
            win = true;
        }

        if (win == true) { onMenu = true; }

        if (!Input.GetMouseButton(1))

        {
            size += Input.mouseScrollDelta.y;
        }
        if (size < 1) size = 1;
        if (size > 10) size = 10;
        transparentPrefab.transform.localScale = new Vector3 (size, size, 1);
        groundPrefab.transform.localScale = new Vector3(size, size, 1);

        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        transparentPrefab.transform.position = mousepos;

        if (Input.GetKeyDown(KeyCode.Mouse0) && onMenu == false)
        {
            Instantiate(groundPrefab, mousepos, Quaternion.identity);
        }

    }

    public void ondMenu()
    { onMenu = true; }

    public void OffdMenu()
    { onMenu = false; }


}
