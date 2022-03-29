using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountPlayTime : MonoBehaviour
{
    public Text textTimer;

    void Start()
    {
        //set start time
        DateTime startTime = DateTime.Now;
        PlayerPrefs.SetString("stTime_1", startTime.ToString());
    }
    void Update()
    {
        string timeStr = PlayerPrefs.GetString("stTime_1");
        DateTime startTime = Convert.ToDateTime(timeStr);
        
        //update current time
        DateTime currentTime = DateTime.Now;
        TimeSpan timeDiff = currentTime - startTime;

        //int diffMinute = timeDiff.Minutes;
        int diffSecond = timeDiff.Seconds;

        textTimer.text = "ÃÊ Â÷ÀÌ: " + diffSecond.ToString();
    }
}