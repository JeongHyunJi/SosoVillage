using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public static class TimeController
{
    public static DateTime time = new DateTime(1900, 1, 1, 9, 0, 0);
    public static bool isStart = true;

    public static void TimeCount()
    {
        time = time.AddSeconds(1);
    }
}

public class CountPlayTime : MonoBehaviour
{
    public Text textTimer;
    public GameObject savePlayer;
    public GameObject filter;
    //처음 시작 시간을 카운트 할 수 있도록
    //public string check = "None";

    void Start()
    {
        if (TimeController.isStart)
        {
            TimeController.time = savePlayer.GetComponent<SavePlayer>().ReturnTime();
            TimeController.isStart = false;
        }
    }

    private void FixedUpdate()
    {
        TimeController.TimeCount();
        if (textTimer)
        {
            textTimer.text = "time " + TimeController.time.ToString("yyyy-MM-dd\n tt h:mm");
        }
        if (filter)
        {
            if (TimeController.time.Hour < 6 || TimeController.time.Hour >= 21) { filter.GetComponent<Image>().color = new Color(0, 0, 22 / 255f, 181 / 255f); } // 한밤중
            else if (TimeController.time.Hour < 9) { filter.GetComponent<Image>().color = new Color(0, 0, 87 / 255f, 174 / 255f); } // 새벽녘
            else if (TimeController.time.Hour < 18) { filter.GetComponent<Image>().color = new Color(255, 255, 255, 0); } // 낮
            else if (TimeController.time.Hour < 21) { filter.GetComponent<Image>().color = new Color(135 / 255f, 0, 0, 51 / 255f); } //해질녘
        }
    }
}