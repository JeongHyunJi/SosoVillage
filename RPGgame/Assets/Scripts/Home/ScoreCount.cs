using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreCount : MonoBehaviour
{
    public static int Score = 0;
    public Text scoreText;

    void Update()
    {
        if (Score == 0&&FarmTimeController.diffSec!=-1)
        {
            scoreText.text = "Crop is Growing Now!";
        }
        else if (0 < Score && Score < 6)
        {
            scoreText.text = Score + " Time";
        }
        else
        {
            scoreText.text = "We get a Corn!";
        }
    }
}
