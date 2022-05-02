using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;



public class CountFarmTime : MonoBehaviour
{
    public static FarmTimeController[] farmTimeControllers = new FarmTimeController[3];
    static bool[] ClickCheck = { false, false, false };
    static int[][] Check = 
        new int[3][] {
            new int[] { 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 0 } }; //시간 중복 체크
    int cur = 0;

    public GameObject savePlayer;
    private GameObject ThisButton;

    private void Awake()
    {
        if (TimeController.isStart)
        {
            farmTimeControllers[0] = GameObject.FindGameObjectsWithTag("Farm")[0].GetComponent<FarmTimeController>();
            farmTimeControllers[1] = GameObject.FindGameObjectsWithTag("Farm")[1].GetComponent<FarmTimeController>();
            farmTimeControllers[2] = GameObject.FindGameObjectsWithTag("Farm")[2].GetComponent<FarmTimeController>();
        }
    }
    public void BtnClick()
    {
        ThisButton = EventSystem.current.currentSelectedGameObject;
        
        if (ThisButton.name == "hole0")
            cur = 0;
        else if (ThisButton.name == "hole1")
            cur = 1;
        else if (ThisButton.name == "hole2")
            cur = 2;
        //이부분 수정 필요
        if (farmTimeControllers[cur].score == 12)
        {
            savePlayer.GetComponent<SavePlayer>().GetCorn();
        }
        else if (farmTimeControllers[cur].score == 0)
        {
            ClickCheck[cur] = true;
            farmTimeControllers[cur].stTime = DateTime.Now;
            PlayerPrefs.SetString("BtnClickTime" + cur, farmTimeControllers[cur].stTime.ToString());
        }
        else
        {
            Reset(cur);
        }
        farmTimeControllers[cur].score = 0;
    }

    public void Reset(int i)
    {
        Check[i] = new int[] { 0, 0, 0, 0, 0, 0 };
        farmTimeControllers[i].diffSec = -1;
        ClickCheck[i] = false;
    }

    public void Update()
    {
        for (int i=0;i<3;i++) {
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
                farmTimeControllers[i].diffHour = timeDiff.Hours;
                farmTimeControllers[i].diffMin = timeDiff.Minutes;
                farmTimeControllers[i].diffSec = timeDiff.Seconds;
                //print(Check[i][0]+" "+Check[i][1]+ " " + Check[i][2]+ " " + Check[i][3]+ " " + Check[i][4]+ " " + Check[i][5]);
                //시간차에 따른 Score 상승
                // 다른 공간에 갔다오면 그만큼의 공백동안 check 가 안돼서 문제가 발생했던 것.
                // check의 의미 알아야 하고 코드 수정내용 공유
                if (farmTimeControllers[i].diffHour == 0 && farmTimeControllers[i].diffMin == 0)
                {
                    if (farmTimeControllers[i].diffSec >= 13)
                    {
                        Reset(i);
                    }
                    else
                    {
                        farmTimeControllers[i].score=(int)farmTimeControllers[i].diffSec;
                        //while(farmTimeControllers[i].score < farmTimeControllers[i].diffSec)
                        //{
                        //    farmTimeControllers[i].score++;
                        //}
                    }

                    //switch (farmTimeControllers[i].diffSec)
                    //{
                    //    case 1:
                    //        if (Check[i][0] == 0)
                    //        {
                    //            farmTimeControllers[i].score++;
                    //            Check[i][0] = 1;
                    //        }
                    //        break;
                    //    case 2:
                    //        if (Check[i][1] == 0)
                    //        {
                    //            farmTimeControllers[i].score++;
                    //            Check[i][1] = 1;
                    //        }
                    //        break;
                    //    case 3:
                    //        if (Check[i][2] == 0)
                    //        {
                    //            farmTimeControllers[i].score++;
                    //            Check[i][2] = 1;
                    //        }
                    //        break;
                    //    case 4:
                    //        if (Check[i][3] == 0)
                    //        {
                    //            farmTimeControllers[i].score++;
                    //            Check[i][3] = 1;
                    //        }
                    //        break;
                    //    case 5:
                    //        if (Check[i][4] == 0)
                    //        {
                    //            farmTimeControllers[i].score++;
                    //            Check[i][4] = 1;
                    //        }
                    //        break;
                    //    case 6:
                    //        if (Check[i][5] == 0)
                    //        {
                    //            farmTimeControllers[i].score++;
                    //            Check[i][5] = 1;
                    //        }
                    //        break;
                    //    case 7:
                    //        Reset(i);
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
        }

    }
}