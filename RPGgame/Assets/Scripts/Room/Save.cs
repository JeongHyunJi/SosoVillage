using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Save : MonoBehaviour
{
    public GameObject suggest;
    public GameObject YesSave;
    Vector2 pos;

    void OffSaveAlarm()
    {
        YesSave.SetActive(false);
    }

    void Start()
    {
        suggest.SetActive(false);
        YesSave.SetActive(false);
        pos = this.gameObject.transform.position;
        print(pos);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "bed")
        {
            suggest.SetActive(true);
            Time.timeScale = 0;
            print("bed와 충돌");
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
            suggest.SetActive(false);
            YesSave.SetActive(true);
            Invoke("OffSaveAlarm", 0.5f);
        }
        else if (BtnName == "Button_n") //저장X
        {
            suggest.SetActive(false);
            print("저장하지않음");
        }
        Time.timeScale = 1;
        Vector2 changeXY = new Vector2(3.4f, -11.6f);
        this.gameObject.transform.position = changeXY;
        //Vector3(6.30131817,-8.10491562,0)
    }
}
