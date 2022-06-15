using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ShootingManager : MonoBehaviour
{
    private PlayerController player;
    private TreantController enemy;
    private float playerStartHP;
    private float enemyStartHP;
    private float DestroyTime = 3f;
    private float TickTime;
    public Slider slider_playerHP;
    public Slider slider_enemyHP;
    public Text startTime;

    public GameObject gameoverText;
    public GameObject RetryText;
    public GameObject ExitText;
    public GameObject ClearText;
    public GameObject FailText;
    SavePlayer saveplayer;
    BGMcontroller bgmController;

    public AudioClip hitFire;
    public AudioClip winSound;
    public AudioClip loseSound;
    AudioSource audioSource;

    private bool gameGoing = true;
    // Start is called before the first frame update
    void Start()
    {
        if (Hearts.heart == 0)
            SceneManager.LoadScene("Forest");
        player = GameObject.Find("player").GetComponent<PlayerController>();
        enemy = GameObject.Find("treant").GetComponent<TreantController>();
        bgmController = GameObject.Find("bgm").GetComponent<BGMcontroller>();
        playerStartHP = player.playerHP;
        enemyStartHP = enemy.treantHP;
        gameoverText.SetActive(false);
        ClearText.SetActive(false);
        FailText.SetActive(false);
        RetryText.SetActive(false);
        ExitText.SetActive(false);
        //IsOpenMenuPanel.SetActive(false);
        saveplayer = FindObjectOfType<SavePlayer>();
        this.audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        TickTime += Time.deltaTime;
        if (TickTime <= 1)
            startTime.text = "2";
        else if (TickTime <= 2)
            startTime.text = "1";
        else if (TickTime <= 3)
        {
            startTime.text = "start";
            Variables.IsGameGoing = true;
        }  
        else if (TickTime >= DestroyTime)
        {
            startTime.text = "";
            if (gameGoing)
            {
                slider_playerHP.transform.position = player.transform.position + new Vector3(0, 0.7f, 0);
                slider_enemyHP.transform.position = enemy.transform.position + new Vector3(0, 0.7f, 0);
                slider_playerHP.value = player.playerHP / playerStartHP;
                slider_enemyHP.value = enemy.treantHP / enemyStartHP;
            }
        }
    }
    public void GameOver(bool isPlayerWin)
    {
        gameGoing = false;
        Variables.IsGameGoing = false;
        Hearts.heart--;
        Hearts.HeartControll();
        gameoverText.SetActive(true);
        RetryText.SetActive(true);
        ExitText.SetActive(true);
        if (isPlayerWin)
        {
            playSound("Win");
            ClearText.SetActive(true);
            slider_enemyHP.gameObject.SetActive(false);
            saveplayer.GetCoins(30);
        }
        else
        {
            playSound("Lose");
            FailText.SetActive(true);
            slider_playerHP.gameObject.SetActive(false);
        }
        bgmController.stopBGM();
    }
    public void playSound(string soundName)
    {
        audioSource.volume = 1f;
        switch (soundName)
        {
            case "Hit":
                audioSource.clip = hitFire;
                audioSource.volume = 0.2f;
                break;
            case "Win":
                audioSource.PlayOneShot(winSound); //PlayOneShot => 소리 동시출력 가능하게하는 함수!
                break;
            case "Lose":
                audioSource.PlayOneShot(loseSound);
                break;
        }
        audioSource.Play();
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
