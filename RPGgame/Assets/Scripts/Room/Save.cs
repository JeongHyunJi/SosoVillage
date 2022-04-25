using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Save : MonoBehaviour
{
    public GameObject suggest;

    void Start()
    {
        suggest.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bed")
        {
            print("bed");
            suggest.SetActive(true);
        }
    }

    public void BtnClick()
    {
        SavePlayer sp = FindObjectOfType<SavePlayer>();
        string BtnName = EventSystem.current.currentSelectedGameObject.name;

        if (BtnName == "Button_y") //저장O
        {
            sp.SaveContent();
            print("저장완료");
        }
        else if (BtnName == "Button_n") //저장X
        {
            suggest.SetActive(false);
            print("저장하지않음");
        }
    }
}
