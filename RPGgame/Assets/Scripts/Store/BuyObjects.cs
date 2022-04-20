using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    public GameObject GameManager;
    int[] invent;

    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;

        //SavePlayer에서 가져오기
        SavePlayer inventorys = FindObjectOfType<SavePlayer>();
        invent = inventorys.ReturnInvent();

        if (BtnName == "item1") //씨앗
        {
            Debug.Log("1사용전: "+invent[0]);
            inventorys.UseInvent(1);
            Debug.Log("1사용후:"+invent[0]);

        }
        else if (BtnName == "item2") //옥수수
        {
            Debug.Log("2추가전: " + invent[1]);
            inventorys.GetInvent(2);
            Debug.Log("2추가후:" + invent[1]);
        }
        else if (BtnName == "item3") //안구워진 빵
        {
            Debug.Log("3추가전: " + invent[2]);
            inventorys.GetInvent(3);
            Debug.Log("3추가후:" + invent[2]);
        }
        else if (BtnName == "item4") //잘구워진 빵
        {
            Debug.Log("4추가전: " + invent[3]);
            inventorys.GetInvent(4);
            Debug.Log("4추가후:" + invent[3]);
        }
        else if (BtnName == "item5") //탄 빵
        {
            Debug.Log("5추가전: " + invent[4]);
            inventorys.GetInvent(5);
            Debug.Log("5추가후:" + invent[4]);
        }
    }
}
