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

    public TMP_Text Highscore2;
    public TMP_Text Score;
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
    }

    public void Pause() { paused = true; }
    public void UnPause() { paused = false; }
     public void Reset()
    {
        if (clock > highscore) { highscore = clock;
            Highscore.text = ("Highscore: " + highscore + "s");
            Highscore2.text = ("Current Highscore: " + highscore + "s");
        }
        clock = 0;
    }

}
