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
        StartCoroutine("TimeAttack");
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;
                if (click_obj.tag.Equals("mole"))
                {
                    Debug.Log(click_obj.name);
                   // click_obj.isClickOk = false;
                    PlusScore();
                }
            }
        }*/
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
                CheckClear();
            }
        }
    }
    public void PlusScore()
    {
        score += 10;
        scoreText.text = "Score: " + (int)score;
    }

    void CheckClear()
    {
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
