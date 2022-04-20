/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    static int one;
    static int two;
    static int three;
    static int four;
    static int five;
    public GameObject GameManager;
 
    private static void BringInv()
    {
        SavePlayer sp = new SavePlayer();
        one = sp.ReturnInvent1();
        two = sp.ReturnInvent2();
        three = sp.ReturnInvent3();
        four = sp.ReturnInvent4();
        five = sp.ReturnInvent5();
    }
    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        BringInv();
        //one = PlayerPrefs.GetInt("saved_1");
        //two = PlayerPrefs.GetInt("saved_2");
        //three = PlayerPrefs.GetInt("saved_3");
        //four = PlayerPrefs.GetInt("saved_4");
        //five = PlayerPrefs.GetInt("saved_5");

        if (BtnName == "item1") //揪狙
        {
            one++;
            PlayerPrefs.SetInt("saved_1", one);
        }
        else if (BtnName == "item2") //苛荐荐
        {
            two++;
            PlayerPrefs.SetInt("saved_2", two);
        }
        else if (BtnName == "item3") //救备况柳 户
        {
            three++;
            PlayerPrefs.SetInt("saved_3", three);
        }
        else if (BtnName == "item4") //肋备况柳 户
        {
            four++;
            PlayerPrefs.SetInt("saved_4", four);
        }
        else if (BtnName == "item5") //藕 户
        {
            five++;
            PlayerPrefs.SetInt("saved_5", five);
        }
        Debug.Log(one + ":" + two + ":" + three + ":" + four + ":" + five);
    }
}*/
