using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    int one;
    int two;
    int three;
    public GameObject GameManager;

    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        //one = SavePlayer.ReturnInvent1();
        two = PlayerPrefs.GetInt("saved_2");
        three = PlayerPrefs.GetInt("saved_3");

        if (BtnName == "item1")
        {
            one++;
            PlayerPrefs.SetInt("saved_1", one);
        }
        else if (BtnName == "item2")
        {
            two++;
            PlayerPrefs.SetInt("saved_2", two);
        }
        else if (BtnName == "item3")
        {
            three++;
            PlayerPrefs.SetInt("saved_3", three);
        }
        Debug.Log(one + ":" + two + ":" + three);
    }
}
