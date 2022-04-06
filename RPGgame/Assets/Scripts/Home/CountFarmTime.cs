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

    //Score에서 중복되지 않도록
    public int n1 = 0;
    public int n2 = 0;
    public int n3 = 0;
    public int n4 = 0;
    public int n5 = 0;
    public int n6 = 0;

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
            if (ScoreCount.Score == 6)
            {
                textTimer.text = "Finish Growing!";
            }
            else
            {
                textTimer.text = "초 차이: " + diffSecond.ToString();
            }
        }

        switch (diffSecond)
        {
            case 1:
                if (n1 == 0)
                {
                    ScoreCount.Score++;
                    n1++;
                }
                break;
            case 2:
                if (n2 == 0)
                {
                    ScoreCount.Score++;
                    n2++;
                }
                break;
            case 3:
                if (n3 == 0)
                {
                    ScoreCount.Score++;
                    n3++;
                }
                break;
            case 4:
                if (n4 == 0)
                {
                    ScoreCount.Score++;
                    n4++;
                }
                break;
            case 5:
                if (n5 == 0)
                {
                    ScoreCount.Score++;
                    n5++;
                }
                break;
            case 6:
                if (n6 == 0)
                {
                    ScoreCount.Score++;
                    n6++;
                }
                break;
            default:
                //Debug.Log("defaul");
                break;
        }
    }
}
