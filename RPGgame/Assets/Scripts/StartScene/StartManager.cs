using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject NameScene;
    public GameObject NameCheckScene;

    public InputField inputField_Name;
    public Text NameCheckText;
    string playerName = "";

    private SavePlayer savePlayer;

    // Start is called before the first frame update
    void Start()
    {
        NameCheckScene.SetActive(false);
        savePlayer = GameObject.Find("StartManager").GetComponent<SavePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickNext()
    {
        if(inputField_Name.text != "")
        {
            playerName = inputField_Name.text;
        }
        NameScene.SetActive(false);
        NameCheckText.text = "Would you like to set the character's name to\n\"" + playerName + "\" ?";
        NameCheckScene.SetActive(true);
    }

    public void ClickStart()
    {
        savePlayer.SetName(playerName);
        savePlayer.SaveContent();
        SceneManager.LoadScene("Home");
    }
    public void ClickBack()
    {
        NameCheckScene.SetActive(false);
        NameScene.SetActive(true);
    }

}
