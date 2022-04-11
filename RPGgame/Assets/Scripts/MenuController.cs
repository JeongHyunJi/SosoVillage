using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //public Texture2D cursorImg;

    private void Start()
    {
        //Cursor.SetCursor(cursorImg, Vector2.zero, CursorMode.ForceSoftware);
        //Cursor.lockState = CursorLockMode.Confined;
    }
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("go to menu");
            SceneManager.LoadScene("MenuScene");
        }
    }

    public void clickMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
