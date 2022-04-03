using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountFarmTime : MonoBehaviour
{
    public Text textTimer;
    bool checkClick = false;
    public int diffSecond = 0;
    public void Btn_Click()
    {
        DateTime startTime = DateTime.Now;
        PlayerPrefs.SetString("stTime", startTime.ToString());
        checkClick = true;
    }
    public void Update()
    {
        if (checkClick)
        {
            string timeStr = PlayerPrefs.GetString("stTime");
            DateTime startTime = Convert.ToDateTime(timeStr);

            //update current time
            DateTime currentTime = DateTime.Now;
            TimeSpan timeDiff = currentTime - startTime;

            //int diffMinute = timeDiff.Minutes;
            diffSecond = timeDiff.Seconds;
            textTimer.text = "ÃÊ Â÷ÀÌ: " + diffSecond.ToString();
        }
    }
}
