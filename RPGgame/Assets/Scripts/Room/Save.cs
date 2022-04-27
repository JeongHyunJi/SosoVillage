using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Save : MonoBehaviour
{
    public GameObject suggest;
    Vector3 pos;

    void Start()
    {
        suggest.SetActive(false);
        //pos = this.GameObject.transform.position;
        //print(pos);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bed")
        {
            suggest.SetActive(true);
            Time.timeScale = 0;
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
        Time.timeScale = 1;
    }
}
