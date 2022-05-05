using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;

        //SavePlayer에서 가져오기
        SavePlayer inventorys = FindObjectOfType<SavePlayer>();

        //----------------------- 구매
        if (BtnName == "seed") //씨앗
        {
            inventorys.GetInvent(1);
            inventorys.UseCoins(30);
        }
        else if (BtnName == "heart") //하트
        {
            inventorys.GetHeart();
            inventorys.UseCoins(300);
        } //----------------------- 판매
        else if (BtnName == "corn") //옥수수
        {
            inventorys.UseInvent(2);
            inventorys.GetCoins(50);
        }
        else if (BtnName == "bread_not") //안구워진 빵
        {
            inventorys.UseInvent(3);
            inventorys.GetCoins(70);
        }
        else if (BtnName == "bread_well") //잘구워진 빵
        {
            inventorys.UseInvent(4);
            inventorys.GetCoins(130);
        }
        else if (BtnName == "bread_burn") //탄 빵
        {
            inventorys.UseInvent(5);
            inventorys.GetCoins(40);
        }
        else if (BtnName == "fish_s") //작은 물고기
        {
            inventorys.UseInvent(6);
            inventorys.GetCoins(10);
        }
        else if (BtnName == "fish_m") //중간 물고기
        {
            inventorys.UseInvent(7);
            inventorys.GetCoins(20);
        }
        else if (BtnName == "fish_l") //큰 물고기
        {
            inventorys.UseInvent(8);
            inventorys.GetCoins(30);
        }
    }
}
