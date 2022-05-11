using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class Variables
{
    public static string asName = "MenuScene";
}

public class MenuController : MonoBehaviour
{

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            clickMenu();
        }
    }

    public void clickMenu()
    {
        Variables.asName = SceneManager.GetActiveScene().name;
        if (Variables.asName == "GameDodugi")
        {
            MoleManager moleManager = FindObjectOfType<MoleManager>();
            moleManager.pauseMoleGame();
        }
        else if (Variables.asName == "GameShooting")
        {
            ShootingManager shootingManager = FindObjectOfType<ShootingManager>();
            shootingManager.pauseShootingGame();
        }
        else if (Variables.asName == "GameCookingReal")
        {
            TimerManager timerManager = FindObjectOfType<TimerManager>();
            timerManager.pauseCookingGame();
        }
        else
        {
            openMenu();
        }
    }
    public void openMenu()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (Variables.asName != "Store" && Variables.asName!="GameCookingReal"&& player != null)
            SavePosition.SaveCurrentPosition(player);
        SceneManager.LoadScene("MenuScene");
    }
}
