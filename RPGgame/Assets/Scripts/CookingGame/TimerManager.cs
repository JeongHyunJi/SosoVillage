using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class TimerManager : MonoBehaviour
{
    public GameObject exit;
    public GameObject NoCornAlarm;
    public GameObject MenuOpenAlarm;
    private Button ClickButton;
    public Text status_text;
    public Text btn_text;

    //sound
    public AudioClip ovensound;
    public AudioClip timersound;
    AudioSource audioSource;

    //game
    bool GameStart = false; //게임 시작 Y/N 검사
    bool SetBtn = false; //버튼 활성화 Y/N 검사

    //bread
    SpriteRenderer breadSR;
    public GameObject bread;

    //time
    float time; //전체 시간
    float cooking_time = 3.5f;
    float rest_time = 1.0f;

    void Start()
    {
        breadSR = bread.GetComponent<SpriteRenderer>();
        NoCornAlarm.SetActive(false);
        MenuOpenAlarm.SetActive(false);
        this.audioSource = GetComponent<AudioSource>();
    }

    //menu click
    public void pauseCookingGame()
    {
        Time.timeScale = 0;
        MenuOpenAlarm.SetActive(true);
    }
    public void ClickIsOpen()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        if (BtnName == "openOkText")
        {
            MenuOpenAlarm.SetActive(false);
            Time.timeScale = 1;
            MenuController menuController = FindObjectOfType<MenuController>();
            menuController.openMenu();
        }
        else if (BtnName == "openCancelText")
        {
            MenuOpenAlarm.SetActive(false);
            Time.timeScale = 1;
        }
    }

    //button click
    public void Btn_Click() 
    {
        SavePlayer inventorys = FindObjectOfType<SavePlayer>();
        int[] inv= inventorys.ReturnInvent();

        if (inv[1] < 2&&GameStart==false) //corn 부족해서 game 불가능
        {
            NoCornAlarm.SetActive(true);
            Invoke("OffAlarm", 2f);
        }

        if (inv[1] >= 2 && !SetBtn) //게임 시작
        {
            inventorys.UseCorn();
            exit.SetActive(false);
            GameStart = true;
            SetBtn = true;
            btn_text.text = "Stop!";
        }
        else if(GameStart) //게임 종료
        {
            SetBtn = false;
            GameObject.FindGameObjectWithTag("cookingBtn").GetComponent<Button>().interactable = false;

            if (cooking_time- rest_time <= time && time <= cooking_time+ rest_time)
            {
                btn_text.text = "<color=#ffe650> Game Complete! </color>";
                Invoke("PrintFinalY", 3f);
                inventorys.GetInvent(4); //익은 빵
            }
            else
            {
                btn_text.text = "<color=#68d168> Game Fail.. </color>";
                if (cooking_time - rest_time > time)
                {
                    Invoke("PrintFinalN_Not", 3f);
                    inventorys.GetInvent(3); //익지 않은 빵
                }
                else
                {
                    Invoke("PrintFinalN_Burn", 3f);
                    inventorys.GetInvent(5); //탄 빵
                }
            }
            time = 0;
            Invoke("SceneChange", 4f);
        }
    }

    public void Update()
    {
        if (SetBtn)
        {
            time += Time.deltaTime;
            if (2.5f <= time && time <= 4.5f)
            {
                status_text.text = "Nice Baking!";
                breadSR.material.color = new Color(0.90f, 0.68f, 0.19f);
            }
            else if (time > 4.5f && time < 6.5f)
            {
                status_text.text = "Bread is Burning!";
                breadSR.material.color = new Color(0.49f, 0.35f, 0.04f);
            }
            else if (time >= 6.5f)
            {
                status_text.text = "Bread is All Burned..";
                breadSR.material.color = new Color(0.0f, 0.0f, 0.0f);
            }
            else
            {
                status_text.text = "Baking Now~";
                breadSR.material.color = new Color(1f, 1f, 1f);
            }
        }
    }

    public void PrintFinalY()
    {
        btn_text.text = "Get a Well baked bread!!";
    }
    public void PrintFinalN_Not()
    {
        btn_text.text = "Get a Not Baked Bread..";
    }
    public void PrintFinalN_Burn()
    {
        btn_text.text = "Get a Burned Bread!";
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Home");
    }

    public void ovenSound()
    {
        if(!GameStart)
        {
            audioSource.clip = timersound;
            audioSource.Play();
        }
        else if (GameStart)
        {
            audioSource.clip = ovensound;
            audioSource.Play();
        }
    }
}