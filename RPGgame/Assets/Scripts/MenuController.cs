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
    //public Texture2D cursorImg;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Debug.Log("go to menu");
            //SceneManager.LoadScene("MenuScene");
            clickMenu();
        }
    }

    public void clickMenu()
    {
        Variables.asName = SceneManager.GetActiveScene().name;
        SavePosition.SaveCurrentPosition(this.gameObject);
        SceneManager.LoadScene("MenuScene");
    }
}
