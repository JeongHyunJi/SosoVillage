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
    public GameObject savePlayer;

    // Start is called before the first frame update

    private void Start()
    {
        Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
        playerName.text = "Name : " + savePlayer.GetComponent<SavePlayer>().GetName();
        coins.text = savePlayer.GetComponent<SavePlayer>().ReturnCoins().ToString() + " $";
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
        Debug.Log("Click Home");
        SceneManager.LoadScene("Home");
    }
    public void GotoForest()
    {
        Debug.Log("Click Forest");
        SceneManager.LoadScene("Forest");
    }
    public void GotoStore()
    {
        Debug.Log("Click Store");
        SceneManager.LoadScene("Store");
    }

    public void GameQuit()
    {
        Debug.Log("Game Quit");
        savePlayer.GetComponent<SavePlayer>().SaveContent();
        Application.Quit();
    }
}
