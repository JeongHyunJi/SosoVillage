using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoleManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text scoreText;
    public GameObject RetryText;
    public GameObject ExitText;
    public GameObject ClearText;
    public GameObject FailText;

    private float time;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameoverText.SetActive(false);
        ClearText.SetActive(false);
        FailText.SetActive(false);
        RetryText.SetActive(false);
        ExitText.SetActive(false);
        StartCoroutine("TimeAttack");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator TimeAttack()
    {
        time = 15;
        while (true)
        {
            time -= Time.deltaTime;
            timeText.text = "Time: " + (int)time;
            yield return null;
            if(time <= 0 )
            {
                StopAllCoroutines();
                MoleSpawner moleSpawner = FindObjectOfType<MoleSpawner>();
                moleSpawner.EndGame();
                gameoverText.SetActive(true);
                RetryText.SetActive(true);
                ExitText.SetActive(true);
                CheckClear();
            }
        }
    }
    public void PlusScore()
    {
        score += 10;
        scoreText.text = "Score: " + (int)score;
    }
    public void clickRetry()
    {
        SceneManager.LoadScene("GameDodugi");

    }

    public void clickExit()
    {
        SceneManager.LoadScene("Forest");
    }

    void CheckClear()
    {
        Hearts.heart--;
        Hearts.HeartControll();
        if (score >= 70)
        {
            ClearText.SetActive(true);
        }
       else
        {
            FailText.SetActive(true);
        }
    }
}
