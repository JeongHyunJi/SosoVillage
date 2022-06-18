using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class CountFarmTime : MonoBehaviour
{
    public static FarmTimeController[] farmTimeControllers = new FarmTimeController[6];
    static bool[] ClickCheck = new bool[6];

    public GameObject savePlayer;
    private GameObject ThisButton;
    private GameObject[] farmList;
    public GameObject ResetAlarm;
    public AudioClip sowSound;
    public AudioClip harvestSound;
    public AudioClip alert;
    AudioSource audioSource;
    int cur = 0;

    private void Awake()
    {
        ResetAlarm.SetActive(false);
        if (TimeController.isStart)
        {
            farmList = GameObject.FindGameObjectsWithTag("Farm");
            System.Array.Sort<GameObject>(farmList, (x, y) => string.Compare(x.name, y.name));
            farmTimeControllers[0] = farmList[0].GetComponent<FarmTimeController>();
            farmTimeControllers[1] = farmList[1].GetComponent<FarmTimeController>();
            farmTimeControllers[2] = farmList[2].GetComponent<FarmTimeController>();
            farmTimeControllers[3] = farmList[3].GetComponent<FarmTimeController>();
            farmTimeControllers[4] = farmList[4].GetComponent<FarmTimeController>();
            farmTimeControllers[5] = farmList[5].GetComponent<FarmTimeController>();
            for (int i = 0; i < 6; i++)
            {
                ClickCheck[i] = PlayerPrefs.HasKey("BtnClickTime" + i); //클릭했는지 여부를 playerpref을 통해 저장
            }
        }
    }

    private void Start()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    public void BtnClick()
    {
        ThisButton = EventSystem.current.currentSelectedGameObject;
        if (ThisButton.name[0] != 't')
            cur = (int)ThisButton.name[4] - 48;

        //이부분 수정 필요
        if (farmTimeControllers[cur].score >= 24) //24분 경과 후 => 옥수수 맺힌 후
        {
            savePlayer.GetComponent<SavePlayer>().GetCorn();
            farmTimeControllers[cur].score = 0;
            ClickCheck[cur] = false;
            PlayerPrefs.DeleteKey("BtnClickTime" + cur); //수확 후 삭제
            playSound("Harvest");
        }
        else if (farmTimeControllers[cur].score == 0) //초기화 상태
        {
            ClickCheck[cur] = true;
            farmTimeControllers[cur].stTime = DateTime.Now;
            PlayerPrefs.SetString("BtnClickTime" + cur, farmTimeControllers[cur].stTime.ToString()); //현재시간으로 저장
            farmTimeControllers[cur].score = 0;
            playSound("Sow");
        }
        else //옥수수 익는 중
        {
            ResetAlarm.SetActive(true);
            playSound("Alert");
            Time.timeScale = 0;
            if (ThisButton.name == "text_ok") // 새로운 함수를 만들어서 위치를 옮겨야 할 듯
            {
                ResetAlarm.SetActive(false);
                ClickCheck[cur] = false;
                farmTimeControllers[cur].score = 0;
            }
            else if (ThisButton.name == "text_cancel")
            {
                ResetAlarm.SetActive(false);
            }
            Time.timeScale = 1;
        }
    }

    public void Update()
    {
        for (int i=0;i<6;i++) {
            //Button이 클릭된 경우
            if (ClickCheck[i] == true)
            {
                //start time 설정
                string ClickTime = PlayerPrefs.GetString("BtnClickTime"+i);
                farmTimeControllers[i].stTime = Convert.ToDateTime(ClickTime);

                //current time 설정
                farmTimeControllers[i].curTime = DateTime.Now;

                //current time과 start time의 차이 정의
                TimeSpan timeDiff = farmTimeControllers[i].curTime - farmTimeControllers[i].stTime;
                farmTimeControllers[i].totalMin = timeDiff.TotalMinutes;
                //시간차에 따른 Score 상승
                //if (farmTimeControllers[i].diffHour == 0 && farmTimeControllers[i].diffMin == 0)
                //{
                    //if (farmTimeControllers[i].totalMin < 25)
                    //{
                        farmTimeControllers[i].score=(float)farmTimeControllers[i].totalMin;
                    //}
                //}
            }
        }

    }
    void playSound(string soundName)
    {
        audioSource.volume = 1f;
        switch (soundName)
        {
            case "Harvest":
                audioSource.clip = harvestSound;
                break;
            case "Sow":
                audioSource.clip = sowSound;
                break;
            case "Alert":
                audioSource.clip = alert;
                break;
        }
        audioSource.Play();
    }
}