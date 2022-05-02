using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;

        //SavePlayer¿¡¼­ °¡Á®¿À±â
        SavePlayer inventorys = FindObjectOfType<SavePlayer>();

        if (BtnName == "item1") //¾¾¾Ñ
        {
            inventorys.UseInvent(1);
            inventorys.UseCoins(1);
        }
        else if (BtnName == "item2") //¿Á¼ö¼ö
        {
            inventorys.GetInvent(2);
            inventorys.GetCoins(3);
        }
        else if (BtnName == "item3") //¾È±¸¿öÁø »§
        {
            inventorys.GetInvent(3);
            inventorys.GetCoins(5);
        }
        else if (BtnName == "item4") //Àß±¸¿öÁø »§
        {
            inventorys.GetInvent(4);
            inventorys.GetCoins(10);
        }
        else if (BtnName == "item5") //Åº »§
        {
            inventorys.GetInvent(5);
            inventorys.GetCoins(3);
        }
    }
}
