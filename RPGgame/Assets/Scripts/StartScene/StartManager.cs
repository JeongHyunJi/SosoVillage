using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject NameScene;
    public GameObject NameCheckScene;
    public GameObject NOName;
    public GameObject NameOK;

    public InputField inputField_Name;
    public Text NameCheckText;
    public Text NameCheckText2;
    string playerName = "";

    private SavePlayer savePlayer;

    // Start is called before the first frame update
    void Start()
    {
        NameCheckScene.SetActive(false);
        NOName.SetActive(false);
        NameOK.SetActive(false);
        NameScene.SetActive(false);
        savePlayer = GameObject.Find("StartManager").GetComponent<SavePlayer>();
    }


    public void ClickStartGame()
    {
        if(savePlayer.IsSaveExist())
        {
            NameOK.SetActive(true);
            NameCheckText2.text = "Start Game  with\n\"" + savePlayer.GetName() + "\" ?";
        }
        else
        {
            NOName.SetActive(true);
        }
    }
    public void ClickNewGame()
    {
        NameScene.SetActive(true);
    }
    public void ClickCloseNameScene()
    {
        NameScene.SetActive(false);
    }    

    public void ClickNext()
    {
        if(inputField_Name.text != "")
        {
            playerName = inputField_Name.text;
            NameScene.SetActive(false);
            NameCheckText.text = "Would  you  like  to  set  the  character's name  to\n\"" + playerName + "\" ?";
            NameCheckScene.SetActive(true);
        };
    }

    public void ClickStart()
    {
        SavePosition.currentPosition = new Vector2(6.5f, -16);
        SceneManager.LoadScene("Home");
    }
    public void ClickStartNewGame()
    {
        savePlayer.startNewGame(playerName); // 새로운 이름과 함께 정보초기화
        savePlayer.SaveContent();
        SavePosition.currentPosition = new Vector2(6.5f, -16);
        SceneManager.LoadScene("Home");
    }
    public void ClickBackStartScene()
    {
        NameOK.SetActive(false);
        NOName.SetActive(false);
    }

    public void ClickBackNameScene()
    {
        NameCheckScene.SetActive(false);
        NameScene.SetActive(true);
    }

}
