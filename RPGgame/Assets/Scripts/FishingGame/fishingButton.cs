using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fishingButton : MonoBehaviour
{
    public bool buttonControll = false; // true면 찌가 멈춤
    public GameObject button;
    
    public void stopFloat()
    {
        Rigidbody2D floatS = GameObject.Find("float"+Pond.currentLevel).GetComponent<GameFishing>().floatRigidbody;
        if (buttonControll)
        {
            floatS.velocity = new Vector2(0, 0); //정지하는 기능 -> 1이면 시간경과. 0이면 정지
            buttonControll = false;
        }
        else
        {
            if (GameFishing.isInPond)
            {
                Debug.Log("다음 레벨로");
                GameObject.Find("FishingLevel").GetComponent<GameLevel>().NextLevel();
            }
            else
            {
                
            }
            //정지하는 기능 -> 1이면 시간경과. 0이면 정지
            GameObject.Find("float"+Pond.currentLevel).GetComponent<GameFishing>().Move();
            //Time.timeScale = 0;
            buttonControll = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
