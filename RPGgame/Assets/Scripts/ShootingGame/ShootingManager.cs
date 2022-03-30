using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootingManager : MonoBehaviour
{
    private PlayerController player;
    private TreantController enemy;
    private float playerStartHP;
    private float enemyStartHP;

    public Slider slider_playerHP;
    public Slider slider_enemyHP;

    public GameObject gameoverText;
    public GameObject RetryText;
    public GameObject ExitText;
    public GameObject ClearText;
    public GameObject FailText;

    private bool gameGoing = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<PlayerController>();
        enemy = GameObject.Find("treant").GetComponent<TreantController>();
        playerStartHP = player.playerHP;
        enemyStartHP = enemy.treantHP;
        gameoverText.SetActive(false);
        ClearText.SetActive(false);
        FailText.SetActive(false);
        RetryText.SetActive(false);
        ExitText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameGoing)
        {
            slider_playerHP.transform.position = player.transform.position +new Vector3(0, 0.7f, 0);
            slider_enemyHP.transform.position = enemy.transform.position + new Vector3(0, 0.7f, 0);
            slider_playerHP.value = player.playerHP / playerStartHP;
            slider_enemyHP.value = enemy.treantHP / enemyStartHP;
        }
    }

    public void GameOver(bool isPlayerWin)
    {
        gameGoing = false;
        Hearts.heart--;
        gameoverText.SetActive(true);
        RetryText.SetActive(true);
        ExitText.SetActive(true);
        if (isPlayerWin)
        {
            ClearText.SetActive(true);
            slider_enemyHP.gameObject.SetActive(false);
        }
        else
        {
            FailText.SetActive(true);
            slider_playerHP.gameObject.SetActive(false);
        }
    }

    public void clickRetry()
    {
        SceneManager.LoadScene("GameShooting");

    }
    public void clickExit()
    {
        SceneManager.LoadScene("Forest");
    }

}
