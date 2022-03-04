using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishingButton : MonoBehaviour
{
    public static bool button = false; // true면 찌가 멈춤
    //public GameObject button;
    
    public void stopFloat()
    {
        if (button)
        {
            Time.timeScale = 1; //정지하는 기능 -> 1이면 시간경과. 0이면 정지
            button = false;
        }
        else
        {
            if (GameFishing.isInPond)
            {
                Debug.Log("다음 레벨로 넘어감");
            }
            else
            {
                Debug.Log("하트 하나 감소");
            }
            Time.timeScale = 0;
            button = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
