using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class CountFarmTime : MonoBehaviour
{
    public FarmTimeController[] farmTimeControllers = new FarmTimeController[3];
    public Text textTimer;
    bool ClickCheck = false;
    int cur = 0;
    int[] Check = { 0, 0, 0, 0, 0, 0 }; //시간 중복 체크
    public GameObject savePlayer;
    public GameObject growPlant;

    private void Start()
    { 
        farmTimeControllers[0] = GameObject.FindGameObjectsWithTag("Farm")[0].GetComponent<FarmTimeController>();
        farmTimeControllers[1] = GameObject.FindGameObjectsWithTag("Farm")[1].GetComponent<FarmTimeController>();
        farmTimeControllers[2] = GameObject.FindGameObjectsWithTag("Farm")[2].GetComponent<FarmTimeController>();
    }
    public void BtnClick()
    {
        GameObject ThisButton = EventSystem.current.currentSelectedGameObject;
        ClickCheck = true;
        if (ThisButton.name == "hole1")
            cur = 0;
        else if (ThisButton.name == "hole2")
            cur = 1;
        else if (ThisButton.name == "hole3")
            cur = 2;
        farmTimeControllers[cur].stTime = DateTime.Now;
        //PlayerPrefs.SetString("BtnClickTime", farmTimeControllers[cur].stTime.ToString());
    }

    public void Reset()
    {
        savePlayer.GetComponent<SavePlayer>().GetCorn();
        ClickCheck = false;
        farmTimeControllers[cur].score = 0;
        for(int i=0; i<6; i++)
        {
            Check[i] = 0;
        }
        farmTimeControllers[cur].diffSec = -1;
    }

    public void FixedUpdate()
    {
        //Button이 클릭된 경우
        if (ClickCheck == true)
        {
            //start time 설정
            //string ClickTime = PlayerPrefs.GetString("BtnClickTime");
            //farmTimeControllers[cur].stTime = Convert.ToDateTime(ClickTime);

            //current time 설정
            farmTimeControllers[cur].curTime = DateTime.Now;

            //current time과 start time의 차이 정의
            TimeSpan timeDiff = farmTimeControllers[cur].curTime - farmTimeControllers[cur].stTime;
            farmTimeControllers[cur].diffHour = timeDiff.Hours;
            farmTimeControllers[cur].diffMin = timeDiff.Minutes;
            farmTimeControllers[cur].diffSec = timeDiff.Seconds;

            //시간차에 따른 Score 상승
            if (farmTimeControllers[cur].diffHour == 0 && farmTimeControllers[cur].diffMin==0)
            {
                switch (farmTimeControllers[cur].diffSec)
                {
                    case 1:
                        if (Check[0] == 0)
                        {
                            farmTimeControllers[cur].score++;
                            Check[0] = 1;
                        }
                        break;
                    case 2:
                        if (Check[1] == 0)
                        {
                            farmTimeControllers[cur].score++;
                            Check[1] = 1;
                        }
                        break;
                    case 3:
                        if (Check[2] == 0)
                        {
                            farmTimeControllers[cur].score++;
                            Check[2] = 1;
                        }
                        break;
                    case 4:
                        if (Check[3] == 0)
                        {
                            farmTimeControllers[cur].score++;
                            Check[3] = 1;
                        }
                        break;
                    case 5:
                        if (Check[4] == 0)
                        {
                            farmTimeControllers[cur].score++;
                            Check[4] = 1;
                        }
                        break;
                    case 6:
                        if (Check[5] == 0)
                        {
                            farmTimeControllers[cur].score++;
                            Check[5] = 1;
                        }
                        break;
                    case 7:
                        Reset();
                        break;
                    default:
                        break;
                }
            }

            //확인
            textTimer.text = farmTimeControllers[cur].curTime.ToString("hh:mm:ss");
        }

    }
}