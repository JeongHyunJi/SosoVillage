using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject Paused;
    public GameObject Main;
    public GameObject Map;
    public GameObject SaveCheckPanel;
    public GameObject QuitCheckPanel;
    // public Texture2D cursorImg;

    public Text playerName;
    public Text coins;
    public Text hearts;
    public Text inventory1;
    public Text inventory2;
    public Text inventory3;
    public Text inventory4;
    public Text inventory5;
    public Text inventory6;//물고기s
    public Text inventory7;//물고기m
    public Text inventory8;//물고기l
    public GameObject savePlayer;
    string sceneName;
    int[] inventory = new int[8];
    int coin;
    int heart;
    // Start is called before the first frame update

    private void Start()
    {
        sceneName = Variables.asName;
        Variables.asName = SceneManager.GetActiveScene().name;
        //Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
        playerName.text = "Name :   " + savePlayer.GetComponent<SavePlayer>().GetName();
        coin = savePlayer.GetComponent<SavePlayer>().ReturnCoins();
        coins.text = coin + " $";
        heart = savePlayer.GetComponent<SavePlayer>().ReturnHeart();
        hearts.text = heart + " EA";
        inventory = savePlayer.GetComponent<SavePlayer>().ReturnInvent();
        inventory1.text = "x " + inventory[0];
        inventory2.text = "x " + inventory[1];
        inventory3.text = "x " + inventory[2];
        inventory4.text = "x " + inventory[3];
        inventory5.text = "x " + inventory[4];
        inventory6.text = "x " + inventory[5];
        inventory7.text = "x " + inventory[6];
        inventory8.text = "x " + inventory[7];
        Paused.SetActive(false);
        Map.SetActive(false);
        SaveCheckPanel.SetActive(false);
        QuitCheckPanel.SetActive(false);
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
        if (sceneName != "Home")
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
        SaveCheckPanel.SetActive(true);
    }
    public void ClickIsSave()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        if (BtnName == "saveOkText")
        {
            Debug.Log("save");
            savePlayer.GetComponent<SavePlayer>().SaveContent();
            SaveCheckPanel.SetActive(false);
        }
        else if (BtnName == "saveCancelText")
        {
            SaveCheckPanel.SetActive(false);
        }

    }
    public void ClickQuit()
    {
        QuitCheckPanel.SetActive(true);
    }
    public void IsQuit()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        if (BtnName == "QuitOkText")
        {
            Debug.Log("Game Quit");
            savePlayer.GetComponent<SavePlayer>().SaveContent();
            Application.Quit();
            QuitCheckPanel.SetActive(false);
        }
        else if (BtnName == "QuitCancelText")
        {
            QuitCheckPanel.SetActive(false);
        }
    }
}
