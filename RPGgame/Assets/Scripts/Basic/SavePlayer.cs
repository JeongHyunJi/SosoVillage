using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePlayer : MonoBehaviour
{
    private static string playerName; //매 씬마다 값이 초기화 되는 것을 방지하기 위해 static으로 변수 선언
    private static int coin;
    private static int[] inventory = new int[8]; //씨앗, 옥수수, 빵(안익음), 빵(잘익음), 빵(탐), 물고기(소,중,대)
    private static string times;
    private static string tutCheck;
    private bool IsSave;

    void Awake()
    {
        IsSave = PlayerPrefs.HasKey("saved_name");
        if (TimeController.isStart) //  한번만 실행되도록 if문 안에 코드 작성
        {
            if (!IsSave)
            {
                Debug.Log("저장된 데이터가 없습니다.");
                playerName = "guest"; //나중에 입력받도록 수정
                coin = 5;
                inventory = new int[] { 1, 1, 1, 1, 1, 0, 0, 0 };
                DateTime startDate = new DateTime(1900, 1, 1, 9, 0, 0);
                times = startDate.ToString(); //yyyy,mm,dd,hh,mm -> 초기세팅 : 1900/1/1/ am 9:00 
                Hearts.heart = 5;
                tutCheck = "0000000000";
            }
            else
            {
                Debug.Log("저장된 데이터가 있습니다.");
                playerName = PlayerPrefs.GetString("saved_name");
                coin = PlayerPrefs.GetInt("saved_coin");
                inventory[0] = PlayerPrefs.GetInt("saved_1"); //inventory의 내용물의 개수를 저장 // 씨앗
                inventory[1] = PlayerPrefs.GetInt("saved_2"); // 옥수수
                inventory[2] = PlayerPrefs.GetInt("saved_3"); // 안익은 빵
                inventory[3] = PlayerPrefs.GetInt("saved_4"); // 익은 빵
                inventory[4] = PlayerPrefs.GetInt("saved_5"); // 탄 빵
                inventory[5] = PlayerPrefs.GetInt("saved_6"); // 작은 물고기
                inventory[6] = PlayerPrefs.GetInt("saved_7"); // 중간 물고기
                inventory[7] = PlayerPrefs.GetInt("saved_8"); // 큰 물고기
                times = PlayerPrefs.GetString("saved_time");
                Hearts.heart = PlayerPrefs.GetInt("saved_hearts");
                tutCheck = PlayerPrefs.GetString("tutCheck");
            }
        }
    }
    // Update is called once per frame

    public void startNewGame(string newName)
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("newgame name: "+newName);
        playerName = newName;
        coin = 5;
        inventory = new int[] { 1, 2, 1, 1, 1, 0, 0, 0 };
        DateTime startDate = new DateTime(1900, 1, 1, 9, 0, 0);
        times = startDate.ToString(); //yyyy,mm,dd,hh,mm -> 초기세팅 : 1900/1/1/ am 9:00 
        Hearts.heart = 5;
        tutCheck = "0000000000";
    }

    public bool IsSaveExist()
    {
        return IsSave;
    }

    public string GetName()
    {
        return playerName;
    }
    public void SetName(string newName)
    {
        playerName = newName;
    }

    public void GetCorn()
    {
        inventory[1]++;
    }

    public void GetHeart()
    {
        if (Hearts.heart == 5)
        {
            Debug.Log("하트 풀충전 완료!");
        }
        else
        {
            Hearts.heart++;
        }
    }
    public int ReturnHeart()
    {
        return Hearts.heart;
    }
    //coin
    public void GetCoins(int num)
    {
        coin += num;
    }
    public void GetCoinCheat()
    {
        coin += 10;
    }
    public int UseCoins(int num)
    {
        if (coin - num < 0)
        {
            Debug.Log("coin 사용 불가");
            return -1;
        }
        else
        {
            coin -= num;
            return 0;
        }
    }
    public int ReturnCoins()
    {
        return coin;
    }

    //time
    public DateTime ReturnTime()
    {
        DateTime tmpTime = Convert.ToDateTime(times);
        return tmpTime;
    }

    //inventory
    public int UseInvent(int num)
    {
        if(inventory[num - 1] == 0)
        {
            Debug.Log("inventory 사용 불가");
            return -1;
        }
        else
        {
            inventory[num - 1]--;
            return 0;
        }
    }
    public void UseCorn()
    {
        inventory[1] -= 2;
    }
    public void GetInvent(int num)
    {
        inventory[num - 1]++;
    }
    public int[] ReturnInvent()
    {
        return inventory;
    }
    public bool GetTutorial(int num)
    {
        print(tutCheck);
        return tutCheck[num] == '0';
    }
    public void SetTutorial(int num)
    {
        tutCheck = string.Format("{0:D10}", int.Parse(tutCheck) + (int)Math.Pow(10,9-num));
        print(tutCheck);
    }

    public void SaveContent()
    {
        PlayerPrefs.SetString("saved_name", playerName);
        PlayerPrefs.SetInt("saved_coin", coin);
        PlayerPrefs.SetInt("saved_1", inventory[0]);
        PlayerPrefs.SetInt("saved_2", inventory[1]);
        PlayerPrefs.SetInt("saved_3", inventory[2]);
        PlayerPrefs.SetInt("saved_4", inventory[3]);
        PlayerPrefs.SetInt("saved_5", inventory[4]);
        PlayerPrefs.SetInt("saved_6", inventory[5]);
        PlayerPrefs.SetInt("saved_7", inventory[6]);
        PlayerPrefs.SetInt("saved_8", inventory[7]);
        PlayerPrefs.SetString("saved_time", TimeController.time.ToString());
        PlayerPrefs.SetInt("saved_hearts", Hearts.heart);
        PlayerPrefs.SetString("tutCheck", tutCheck);
        PlayerPrefs.Save();
    }
}
