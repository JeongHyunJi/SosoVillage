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
    string ClickTime;
    DateTime stTime;
    TimeSpan timeDiff;
    float TickTime = 0f;
    TimeSpan term = new TimeSpan(0, 5, 0);

    private void Start()
    {
        panel.SetActive(false);
        print(panel.activeSelf);
        ClickTime = PlayerPrefs.GetString("Heart_time");
        stTime = Convert.ToDateTime(ClickTime);
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
            TickTime = 0;
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
            TickTime = 0;
    }

    private void FixedUpdate()
    {
        timeDiff = term - (DateTime.Now - stTime);
        TimeText.text = timeDiff.Minutes + ":" + timeDiff.Seconds;
        timeDiff = term - (DateTime.Now - stTime);
        if (TickTime <= 2)
        {
            TickTime += Time.deltaTime;
        }
        else
            panel.SetActive(false);
    }
}
