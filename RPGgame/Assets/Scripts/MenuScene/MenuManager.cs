using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject player;

    public GameObject Paused;

    public GameObject Main;

    public GameObject Map;

   // public Texture2D cursorImg;

    public Text playerName;
    public Text coins;
    public Text inventory1;
    public Text inventory2;
    public Text inventory3;
    public Text inventory4;
    public Text inventory5;
    public GameObject savePlayer;
    string sceneName;
    int[] inventory = new int[5];
    int coin;

    // Start is called before the first frame update

    private void Start()
    {
        sceneName = Variables.asName;
        Variables.asName = SceneManager.GetActiveScene().name;
        //Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
        playerName.text = "Name :   " + savePlayer.GetComponent<SavePlayer>().GetName();
        coin = savePlayer.GetComponent<SavePlayer>().ReturnCoins();
        coins.text = coin + " $";
        inventory = savePlayer.GetComponent<SavePlayer>().ReturnInvent();
        inventory1.text = "x " + inventory[0];
        inventory2.text = "x " + inventory[1];
        inventory3.text = "x " + inventory[2];
        inventory4.text = "x " + inventory[3];
        inventory5.text = "x " + inventory[4];
        Paused.SetActive(false);
        Map.SetActive(false);
    }

    public void openPaused()
    {
        Paused.SetActive(true);
        Map.SetActive(false);
        Main.SetActive(false);
    }
    public void openMain()
    {
        Paused.SetActive(false);
        Map.SetActive(false);
        Main.SetActive(true);
    }
    public void openMap()
    {
        Paused.SetActive(false);
        Map.SetActive(true);
        Main.SetActive(false);
    }

    public void GotoHome()
    {
        if(sceneName!="Home")
            SavePosition.currentPosition = new Vector2(6, -16);
        SceneManager.LoadScene("Home");
    }
    public void GotoForest()
    {
        if (sceneName != "Forest")
            SavePosition.currentPosition = new Vector2(0, 0);
        SceneManager.LoadScene("Forest");
    }
    public void GotoStore()
    {
        SceneManager.LoadScene("Store");
    }
    public void GotoBack()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ClickSave()
    {
        Debug.Log("Save");
        savePlayer.GetComponent<SavePlayer>().SaveContent();
    }
    public void GameQuit()
    {
        Debug.Log("Game Quit");
        savePlayer.GetComponent<SavePlayer>().SaveContent();
        Application.Quit();
    }
}
