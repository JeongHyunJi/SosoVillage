using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamePause : MonoBehaviour
{
    public GameObject IsOpenMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        IsOpenMenuPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Hearts.heart--;
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
