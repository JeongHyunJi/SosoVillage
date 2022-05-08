using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject panel;
    public Text TimeText;
    private void Start()
    {
        panel.SetActive(false);
    }
    public void GoToFishingGame()
    {
        if (Hearts.heart != 0)
        {
            SavePosition.SaveCurrentPosition(this.gameObject);
            SceneManager.LoadScene("GameFishing");
        }
        else
        {
            panel.SetActive(true);
            HeartZero();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (Hearts.heart != 0)
        {
            if (other.gameObject.CompareTag("treants"))
                SceneManager.LoadScene("GameShooting");
            else if (other.gameObject.CompareTag("moles"))
                SceneManager.LoadScene("GameDodugi");
        }
        else
            HeartZero();
    }

    void HeartZero()
    {
        string ClickTime = PlayerPrefs.GetString("Heart_time");
        DateTime stTime = Convert.ToDateTime(ClickTime);

        //current time과 start time의 차이 정의

        DateTime st = DateTime.Now;
        DateTime now = DateTime.Now;
        TimeSpan span = now - st;
        TimeSpan term = new TimeSpan(0, 5, 0);
        TimeSpan timeDiff = term - (now - stTime);
        while (span.TotalSeconds < 3)
        {
            TimeText.text = timeDiff.ToString();
            now = DateTime.Now;
            span = now - st;
            timeDiff = term - (now - stTime);
        }
        panel.SetActive(false);
    }
}
