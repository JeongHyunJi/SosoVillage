using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishingButton : MonoBehaviour
{
    bool button = false; // true면 찌가 멈춤
    //public GameObject button;

    public void stopFloat()
    {
        if (button)
        {
            Time.timeScale = 1; //정지하는 기능 -> 1이면 정지. 0이면 시간경과
            button = false;
        }
        else
        {
            Time.timeScale = 0;
            button = true;
        }
        //gameObject.GetComponent<GameFishing>()
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
