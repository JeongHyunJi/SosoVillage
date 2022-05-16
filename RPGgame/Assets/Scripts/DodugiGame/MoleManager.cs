using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MoleManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text scoreText;
    public Text startTime;
    public GameObject RetryText;
    public GameObject ExitText;
    public Text ClearText;
    public GameObject FailText;


    private float time;
    private float score;

   SavePlayer saveplayer;

    // Start is called before the first frame update
    void Start()
    {
        if (Hearts.heart == 0)
            SceneManager.LoadScene("Forest");
        score = 0;
        gameoverText.SetActive(false);
        FailText.SetActive(false);
        RetryText.SetActive(false);
        ExitText.SetActive(false);
        //IsOpenMenuPanel.SetActive(false);
        StartCoroutine("TimeAttack");
        saveplayer = FindObjectOfType<SavePlayer>();
    }

    private IEnumerator TimeAttack()
    {
        yield return new WaitForSeconds(1);
        startTime.text = "2";
        yield return new WaitForSeconds(1);
        startTime.text = "1";
        yield return new WaitForSeconds(1);
        startTime.text = "START!";
        yield return new WaitForSeconds(1);
        startTime.text = "";
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
            float coinF = score / 2;
            int coinI = (int)coinF;
            ClearText.text = "Clear! get " + coinI + "$";
            saveplayer.GetCoins(coinI);
        }
       else
        {
            ClearText.text = "";
            FailText.SetActive(true);
        }
    }
}
