using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public static int Score = 0;
    public Text scoreText;
    public GameObject button;

    void Update()
    {
        scoreText.text = Score + "Á¡";
        if (Score >= 6)
        {
            scoreText.text = "We get a Corn!";
            Score = 0;
        }
    }

    public void ScoreUp()
    {
        Score++;
    }
}
