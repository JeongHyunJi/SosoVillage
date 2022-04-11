using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public static class TimeController
{
    public static DateTime time = new DateTime(PlayerPrefs.GetInt("saved_year"), PlayerPrefs.GetInt("saved_month"), PlayerPrefs.GetInt("saved_day"),
        PlayerPrefs.GetInt("saved_hour"), PlayerPrefs.GetInt("saved_minite"), 0);
    
    public static void TimeCount()
    {
        time = time.AddSeconds(1);
    }
}

public class CountPlayTime : MonoBehaviour
{
    public Text textTimer;
    public GameObject savePlayer;

    //처음 시작 시간을 카운트 할 수 있도록
    //public string check = "None";

    //void Start()
    //{
    //    //set start time
    //    if (SceneManager.GetActiveScene().name == "Home")
    //    {
    //        if (check != "Complete")
    //        {
    //            DateTime startTime = DateTime.Now;
    //            PlayerPrefs.SetString("stTime_1", startTime.ToString());
    //            check = "Complete";
    //        }
    //    }
    //}
    //void Update()
    //{
    //    string timeStr = PlayerPrefs.GetString("stTime_1");
    //    DateTime startTime = Convert.ToDateTime(timeStr);

    //    //update current time
    //    DateTime currentTime = DateTime.Now;
    //    TimeSpan timeDiff = currentTime - startTime;

    //    //int diffMinute = timeDiff.Minutes;
    //    int diffSecond = timeDiff.Seconds;

    //    textTimer.text = "초 차이: " + diffSecond.ToString();
    //}

    private void FixedUpdate()
    {
        TimeController.TimeCount();
        textTimer.text = "time " + TimeController.time.ToString("yyyy년 MM월 dd일\n tt hh:mm");
    }
}