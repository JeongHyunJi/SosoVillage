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
    private GameObject[] MainInv; //inventoryµé
    // public Texture2D cursorImg;

    public Text playerName;
    public Text coins;
    public Text hearts;

    public GameObject savePlayer;
    string sceneName;
    int[] inventory = new int[8];
    int coin;
    int heart;

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
        MainInv = GameObject.FindGameObjectsWithTag("MenuInv");
        for (int i = 0; i < 8; i++)
        {
            MainInv[i].GetComponent<UnityEngine.UI.Text>().text = "x " + inventory[i];
            print(MainInv[i]);
        }
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
