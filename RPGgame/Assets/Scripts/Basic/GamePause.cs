using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    public GameObject IsOpenMenuPanel;

    void Start()
    {
        IsOpenMenuPanel.SetActive(false);
    }
    public void pauseGame()
    {
        Time.timeScale = 0;
        IsOpenMenuPanel.SetActive(true);
    }
    public void ClickIsOpen()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;

        if (BtnName == "openOkText")
        {
            if (SceneManager.GetActiveScene().name != "GameCookingReal" && Variables.IsGameGoing == true)
            {
                Hearts.heart--;
                Variables.IsGameGoing = false;
            }
            IsOpenMenuPanel.SetActive(false);
            Time.timeScale = 1;
            MenuController menuController = FindObjectOfType<MenuController>();
            menuController.openMenu();
        }
        else if (BtnName == "openCancelText")
        {
            IsOpenMenuPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
