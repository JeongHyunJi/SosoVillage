using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayer : MonoBehaviour
{
    private string playerName;
    private static int coin;
    private int[] inventory = new int[5];
    private int[] times = new int[5];

    private bool IsSave;
    // Start is called before the first frame update
    void Start()
    {
        IsSave = PlayerPrefs.HasKey("saved_name");

        if (!IsSave)
        {
            Debug.Log("저장된 데이터가 없습니다.");
            playerName = "guest"; //나중에 입력받도록 수정
            PlayerPrefs.SetString("saved_name", playerName);
            coin = 5;
            inventory = new int[] { 0, 0, 0, 0, 0 };
            times = new int[] { 2022, 4, 10, 0, 0 }; //yyyy,mm,dd,hh,mm
            //Debug.Log(playerName);
        }
        else
        {
            Debug.Log("저장된 데이터가 있습니다.");
            playerName = PlayerPrefs.GetString("saved_name");
            coin = PlayerPrefs.GetInt("saved_coin");
            inventory[0] = PlayerPrefs.GetInt("saved_1"); //inventory의 내용물의 개수를 저장
            inventory[1] = PlayerPrefs.GetInt("saved_2");
            inventory[2] = PlayerPrefs.GetInt("saved_3");
            inventory[3] = PlayerPrefs.GetInt("saved_4");
            inventory[4] = PlayerPrefs.GetInt("saved_5");
            times[0] = PlayerPrefs.GetInt("saved_year");
            times[1] = PlayerPrefs.GetInt("saved_month");
            times[2] = PlayerPrefs.GetInt("saved_day");
            times[3] = PlayerPrefs.GetInt("saved_hour");
            times[4] = PlayerPrefs.GetInt("saved_minite");

        }
    }

    // Update is called once per frame
    public string GetName()
    {
        return PlayerPrefs.GetString("saved_name");
    }

    public void GetCoins(int num)
    {
        coin += num;
    }

    public void UseCoind(int num) 
    {
        coin -= num;
    }

    public int ReturnCoins()
    {
        return coin;
    }

    public DateTime ReturnTime()
    {
        return new DateTime(times[0], times[1], times[2], times[3], times[4], 0);
    }

    public void SaveContent()
    {
        PlayerPrefs.SetInt("saved_coin", coin);
        PlayerPrefs.SetInt("saved_1", inventory[0]);
        PlayerPrefs.SetInt("saved_2", inventory[1]);
        PlayerPrefs.SetInt("saved_3", inventory[2]);
        PlayerPrefs.SetInt("saved_4", inventory[3]);
        PlayerPrefs.SetInt("saved_5", inventory[4]);
        PlayerPrefs.SetInt("saved_year", TimeController.time.Year);
        PlayerPrefs.SetInt("saved_month", TimeController.time.Month);
        PlayerPrefs.SetInt("saved_day", TimeController.time.Day);
        PlayerPrefs.SetInt("saved_hour", TimeController.time.Hour);
        PlayerPrefs.SetInt("saved_minite", TimeController.time.Minute);
        PlayerPrefs.Save();
    }
}
