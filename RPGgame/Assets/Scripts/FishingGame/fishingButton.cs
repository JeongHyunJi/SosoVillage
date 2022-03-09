using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class fishingButton : MonoBehaviour
{
    public bool buttonControll = false; // false면 찌가 멈춤
    public GameObject button;
    
    public void stopButtonController()
    {
        GameObject ThisButton = EventSystem.current.currentSelectedGameObject;
        button = GameObject.FindGameObjectsWithTag("GameController")[Pond.currentLevel - 1];
        if (ThisButton == button)
            stopFloat();
    }

    public void stopFloat()
    {
        if (!buttonControll)
        {
            Time.timeScale = 1;
            buttonControll = false;
        }
        else
        {
            if (GameFishing.isInPond)
            {
                GameFishing.isInPond = false;
                if (Pond.currentLevel < 3)
                {
                    Pond.currentLevel++;
                    GameFishing.floats[Pond.currentLevel - 2].SetActive(false);
                    GameFishing.floats[Pond.currentLevel-1].SetActive(true);
                    GameObject.FindWithTag("Pond").GetComponent<Pond>().Restart();
                }
                else
                {
                    Debug.Log("success");
                }
            }
            else
            {
                Debug.Log("이전 씬으로"); //씬 전환
            }
            Time.timeScale = 0; //정지하는 기능 -> 1이면 시간경과. 0이면 정지
            buttonControll = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
