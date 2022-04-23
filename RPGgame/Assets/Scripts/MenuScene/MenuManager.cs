using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject player;
    //public GameObject StatusText;
    //public GameObject MapText;
    //public GameObject PausedText;

    public GameObject Paused;
    //public GameObject ContinueText;
    //public GameObject QuitText;

    public GameObject Main;

    public GameObject Map;
    //public GameObject HomeText;
    //public GameObject ForestText;
    //public GameObject StoreText;

    public Texture2D cursorImg;

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

    // Start is called before the first frame update

    private void Start()
    {
        sceneName = Variables.asName;;
        Variables.asName = SceneManager.GetActiveScene().name;
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
        playerName.text = "Name : " + savePlayer.GetComponent<SavePlayer>().GetName();
        coins.text = savePlayer.GetComponent<SavePlayer>().ReturnCoins().ToString() + " $";
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
        SceneManager.LoadScene("Home");
    }
    public void GotoForest()
    {
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
        savePlayer.GetComponent<SavePlayer>().SaveContent();
    }
    public void GameQuit()
    {
        Debug.Log("Game Quit");
        savePlayer.GetComponent<SavePlayer>().SaveContent();
        Application.Quit();
    }
}
