using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class fishingButton : MonoBehaviour
{
    public static bool buttonControll = true; // true면 찌가 멈춤
    public GameObject button;
    public Text buttonText;
    public static bool isSuccess = false;
    public Transform panel;
    public GameObject savePlayer;

    public void stopButtonController()
    {
        GameObject ThisButton = EventSystem.current.currentSelectedGameObject; //방금 선택한 오브젝트(버튼)
        button = GameObject.FindGameObjectsWithTag("GameController")[Pond.currentLevel - 1]; //원하는 오브젝트
        if (ThisButton == button) // 이름이 같은지 확인
            stopFloat();
    }

    public void stopFloat()
    {
        if (buttonControll)
        {
            GameFishing.floats[Pond.currentLevel-1].GetComponent<GameFishing>().Move(); 
            buttonControll = false;
        }
        else
        {
            GameFishing.floats[Pond.currentLevel-1].GetComponent<GameFishing>().Stop(); //정지하는 기능 -> 1이면 시간경과. 0이면 정지
            buttonControll = true;
            if (GameFishing.isInPond)
            {
                GameFishing.isInPond = false;
                if (Pond.currentLevel < 3)
                {
                    Pond.currentLevel++;
                    GameFishing.floats[Pond.currentLevel - 2].SetActive(false);
                    GameFishing.floats[Pond.currentLevel - 1].SetActive(true);
                    GameObject.FindWithTag("Pond").GetComponent<Pond>().Restart();
                }
                else
                {
                    isSuccess = true;
                    savePlayer.GetComponent<SavePlayer>().GetInvent(5 + GameLevel.level);
                    panel.GetComponent<GameOver>().Gameover();
                }
            }
            else
            {
                panel.GetComponent<GameOver>().Gameover();
            }
        }
        buttonText.text = buttonControll ? "start" : "stop";
    }
}
