using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //public Rigidbody2D rb;

    public double playerx;
    public double playery;
    public double cameraz = -12;
    public bool faceright = true;
    //  public Vector3 playerpos;
    public Transform player;
    public Transform cameratransform;
    // public int jumptimer;

    //[SerializeField] private Transform groundcheck;
   // [SerializeField] private Transform roofcheck;
    public Transform allplayer;
    public Transform topright;
    public Transform bottomright;
   // public Transform sidechecktwo;
    public Transform topleft;
    public Transform bottomleft;
  //  public Transform leftchecktwo;
    public Transform groundcheck;
    public Transform roofcheck;
   // public batterylevel neededscript;
//public TMP_Text scoretext;
//public TMP_Text endscore;
  //  public TMP_Text depth;
//

    [SerializeField] private LayerMask groundlayer;
    double jumping = 0;
    bool canInteract = false;
    GameObject collref;
    public Stack<GameObject> carry = new Stack<GameObject>();
    GameObject drop;
    public int carryload = 15;
    float carryweight;
    List<GameObject> ContactList = new List<GameObject>();

    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //    allplayer.position = (new Vector3(0, 10, 0));
        //     cameratransform.position = (new Vector3(0, 10, -15));
    }

    // Update is called once per frame
    void Update()
    {
        // jumptimer -= 1;

        if (Input.GetKey(KeyCode.D) && !IsRightone() && !IsRighttwo()) playerx += Time.deltaTime * 04;
        if (Input.GetKey(KeyCode.A) && !IsLeftone() && !IsLefttwo()) playerx -= Time.deltaTime * 04;

        if (Input.GetKey(KeyCode.W) && !IsRoofed() && jumping == 0) jumping = 1;
        else jumping = 0;
        if (jumping != 0)
        {
            playery += 0.2; 
            jumping -= 0.2;
        }
       // if (Input.GetKey(KeyCode.Y)) Debug.Log(carryweight);

        if (!IsGrounded()  && Input.GetKey(KeyCode.S)) { playery -= 4 * Time.deltaTime; }
        else if (!IsGrounded()) playery -= 1.25 * Time.deltaTime;

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && cameraz < -5) cameraz += 0.5;
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && cameraz > -15) cameraz -= 00.5;

        allplayer.position = (new Vector3((float)playerx, (float)playery, 0));
        cameratransform.position = new Vector3((float)playerx, (float)playery, (int)cameraz);
        Flip();
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.01f, groundlayer);
    }
    private bool IsRoofed()
    {
        return Physics2D.OverlapCircle(roofcheck.position, 0.04f, groundlayer);
    }
    /**private bool IsGroundedtwo()
    {
        return Physics2D.OverlapCircle(groundchecktwo.position, 0.01f, groundlayer);
    }
    private bool IsRoofedtwo()
    {
        return Physics2D.OverlapCircle(roofchecktwo.position, 0.04f, groundlayer);
    }
    **/
    private bool IsRightone()
    {
        return Physics2D.OverlapCircle(topright.position, 0.04f, groundlayer);
    }
    private bool IsRighttwo()
    {
        return Physics2D.OverlapCircle(bottomright.position, 0.04f, groundlayer);
    }
   /** private bool IsRightthree()
    {
        return Physics2D.OverlapCircle(sidechecktwo.position, 0.04f, groundlayer);
    }**/
    private bool IsLeftone()
    {
        return Physics2D.OverlapCircle(topleft.position, 0.04f, groundlayer);
    }
    private bool IsLefttwo()
    {
        return Physics2D.OverlapCircle(bottomleft.position, 0.04f, groundlayer);
    }/**
    private bool IsLeftThree()
    {
        return Physics2D.OverlapCircle(leftchecktwo.position, 0.04f, groundlayer);
    }**/

    void Flip()
    {
        if (Input.GetKeyDown(KeyCode.A) && faceright == true) player.localScale = new Vector3(-1, 1, 1);
        if (Input.GetKeyDown(KeyCode.D) && faceright == false) player.localScale = new Vector3(-1, 1, 1);
    }
}

