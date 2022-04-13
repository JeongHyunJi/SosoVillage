using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyObjects : MonoBehaviour
{
    public static int Item1 = 0;
    public static int Item2 = 0;
    public static int Item3 = 0;
    
    public void BtnClick()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        if (BtnName == "item1")
        {
            Item1++;
        }
        else if (BtnName == "item2")
        {
            Item2++;
        }
        else if (BtnName == "item3")
        {
            Item3++;
        }
        Debug.Log(Item1 + ":" + Item2 + ":" + Item3);
    }
}
