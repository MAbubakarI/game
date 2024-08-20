using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    float clock = 0;
    float highscore = 0;
    bool paused = true;
    public TMP_Text Highscore;
    public TMP_Text winscore;

    public TMP_Text Highscore2;
    public TMP_Text Score;
    public int winheight = 500;//game ends(can change depending on map height)
    public Transform player;
    public bool win;
    public GameObject winMenu;
    // Start is called before the first frame update
    void Start()
    {
        clock = 0;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused == false)
        {
            clock += Time.deltaTime;
        }
        Score.text = ("Score: "+clock+"s");

        if (player.position.y>winheight)
        { paused = true;
            win = true;
        }
        if (win == true)
        {
            winscore.text = ("Finished in "+clock+"s");
            winMenu.SetActive(true);
        }
    }

    public void Pause() { paused = true; }
    public void UnPause() { paused = false; }
     public void Reset()
    {
        win = false;
        if (clock > highscore) { highscore = clock;
            Highscore.text = ("Highscore: " + highscore + "s");
            Highscore2.text = ("Current Highscore: " + highscore + "s");
        }
        clock = 0;

        //anthony will do other reset stuff to reset map


    }

}
