using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    float clock = 0;
    float highscore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
    }


     void Reset()
    {
        if (clock > highscore) { highscore = clock; }
        clock = 0;
    }

}
