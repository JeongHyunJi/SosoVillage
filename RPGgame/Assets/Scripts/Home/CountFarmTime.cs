using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;



public class CountFarmTime : MonoBehaviour
{
    static FarmTimeController[] farmTimeControllers = new FarmTimeController[3];
    public Text textTimer;
    static bool[] ClickCheck = { false, false, false };
    int cur = 0;
    static int[][] Check = new int[3][] {
        new int[] { 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0 },
        new int[] { 0, 0, 0, 0, 0, 0 } }; //시간 중복 체크
    public GameObject savePlayer;
    public GameObject growPlant;
    private GameObject ThisButton;

    private void Start()
    { 
        farmTimeControllers[0] = GameObject.FindGameObjectsWithTag("Farm")[0].GetComponent<FarmTimeController>();
        farmTimeControllers[1] = GameObject.FindGameObjectsWithTag("Farm")[1].GetComponent<FarmTimeController>();
        farmTimeControllers[2] = GameObject.FindGameObjectsWithTag("Farm")[2].GetComponent<FarmTimeController>();
    }
    public void BtnClick()
    {
        ThisButton = EventSystem.current.currentSelectedGameObject;
        
        if (ThisButton.name == "hole1")
            cur = 0;
        else if (ThisButton.name == "hole2")
            cur = 1;
        else if (ThisButton.name == "hole3")
            cur = 2;
        ClickCheck[cur] = true;
        farmTimeControllers[cur].stTime = DateTime.Now;
        PlayerPrefs.SetString("BtnClickTime"+cur, farmTimeControllers[cur].stTime.ToString());
    }

    public void Reset(int i)
    {
        savePlayer.GetComponent<SavePlayer>().GetCorn();
        ClickCheck[i] = false;
        Check[i] = new int[] { 0,0,0,0,0,0};
        farmTimeControllers[i].diffSec = -1;
        farmTimeControllers[i].score = 0;
    }

    public void Update()
    {
        for (int i=0;i<3;i++) {
            //Button이 클릭된 경우
            if (ClickCheck[i] == true)
            {
                //start time 설정
                string ClickTime = PlayerPrefs.GetString("BtnClickTime"+i);
                farmTimeControllers[cur].stTime = Convert.ToDateTime(ClickTime);

                //current time 설정
                farmTimeControllers[i].curTime = DateTime.Now;

                //current time과 start time의 차이 정의
                TimeSpan timeDiff = farmTimeControllers[i].curTime - farmTimeControllers[i].stTime;
                farmTimeControllers[i].diffHour = timeDiff.Hours;
                farmTimeControllers[i].diffMin = timeDiff.Minutes;
                farmTimeControllers[i].diffSec = timeDiff.Seconds;

                //시간차에 따른 Score 상승
                if (farmTimeControllers[i].diffHour == 0 && farmTimeControllers[i].diffMin == 0)
                {
                    switch (farmTimeControllers[i].diffSec)
                    {
                        case 1:
                            if (Check[i][0] == 0)
                            {
                                farmTimeControllers[i].score++;
                                Check[i][0] = 1;
                            }
                            break;
                        case 2:
                            if (Check[i][1] == 0)
                            {
                                farmTimeControllers[i].score++;
                                Check[i][1] = 1;
                            }
                            break;
                        case 3:
                            if (Check[i][2] == 0)
                            {
                                farmTimeControllers[i].score++;
                                Check[i][2] = 1;
                            }
                            break;
                        case 4:
                            if (Check[i][3] == 0)
                            {
                                farmTimeControllers[i].score++;
                                Check[i][3] = 1;
                            }
                            break;
                        case 5:
                            if (Check[i][4] == 0)
                            {
                                farmTimeControllers[i].score++;
                                Check[i][4] = 1;
                            }
                            break;
                        case 6:
                            if (Check[i][5] == 0)
                            {
                                farmTimeControllers[i].score++;
                                Check[i][5] = 1;
                            }
                            break;
                        case 7:
                            Reset(i);
                            break;
                        default:
                            break;
                    }
                }

                //확인
                textTimer.text = farmTimeControllers[i].curTime.ToString("hh:mm:ss");
            }
        }

    }
}