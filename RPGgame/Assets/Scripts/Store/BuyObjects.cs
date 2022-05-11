using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    public GameObject Alarm;
    public Text AlarmText;
    public void OffAlarm()
    {
        Alarm.SetActive(false);
    }

    private SavePlayer inventorys;
    public Text coinText;
    public GameObject[] setOne;
    public GameObject[] setTwo;
    private void Start()
    {
        inventorys = FindObjectOfType<SavePlayer>();
        for(int i = 0; i < setTwo.Length; i++)
        {
            setTwo[i].SetActive(false);
        }
        OffAlarm();
    }

    private void Update()
    {
        coinText.text = inventorys.ReturnCoins() + " $";
    }

    private void PrintAlarm(int use,string type)
    {
        if (use == -1)
        {
            Alarm.SetActive(true);
            if(type=="coin")
                AlarmText.text = "Not Enough Coin!";
            if(type=="inv")
                AlarmText.text = "Not Enough Stock!";
            Invoke("OffAlarm", 2f);
        }
    }

    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(BtnName);
        int use;
        //****************************버튼이름 다 수정***************//
        //----------------------- 구매
        if (BtnName == "seed_btn") //씨앗
        {
            inventorys.GetInvent(1);
            use=inventorys.UseCoins(30);
            PrintAlarm(use, "coin");
        }
        else if (BtnName == "heart_btn") //하트
        {
            inventorys.GetHeart();
            use=inventorys.UseCoins(300);
            PrintAlarm(use, "coin");
        } //----------------------- 판매
        else if (BtnName == "corn_btn") //옥수수
        {
            use=inventorys.UseInvent(2);
            PrintAlarm(use, "inv");
            inventorys.GetCoins(50);
        }
        else if (BtnName == "notBread_btn") //안구워진 빵
        {
            use=inventorys.UseInvent(3);
            PrintAlarm(use, "inv");
            inventorys.GetCoins(70);
        }
        else if (BtnName == "wellBread_btn") //잘구워진 빵
        {
            use=inventorys.UseInvent(4);
            PrintAlarm(use, "inv");
            inventorys.GetCoins(130);
        }
        else if (BtnName == "burnBread_btn") //탄 빵
        {
            use=inventorys.UseInvent(5);
            PrintAlarm(use, "inv");
            inventorys.GetCoins(40);
        }
        else if (BtnName == "Sfish_btn") //작은 물고기
        {
            use=inventorys.UseInvent(6);
            PrintAlarm(use, "inv");
            inventorys.GetCoins(10);
        }
        else if (BtnName == "Mfish_btn") //중간 물고기
        {
            use=inventorys.UseInvent(7);
            PrintAlarm(use, "inv");
            inventorys.GetCoins(20);
        }
        else if (BtnName == "Lfish_btn") //큰 물고기
        {
            use=inventorys.UseInvent(8);
            PrintAlarm(use, "inv");
            inventorys.GetCoins(30);
        }
    }
    public void ClickLeftBtn()
    {
        Debug.Log("clickleft");
        for (int i = 0; i < setOne.Length; i++)
        {
            setOne[i].SetActive(true);
        }
        for (int i = 0; i < setTwo.Length; i++)
        {
            setTwo[i].SetActive(false);
        }
    }
    public void ClickRighttBtn()
    {
        for (int i = 0; i < setOne.Length; i++)
        {
            setOne[i].SetActive(false);
        }
        for (int i = 0; i < setTwo.Length; i++)
        {
            setTwo[i].SetActive(true);
        }
    }
}
