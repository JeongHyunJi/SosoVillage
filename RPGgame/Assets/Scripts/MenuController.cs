using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update

    private void Start()
    {
        Debug.Log("MenuController start");
    }
    public void clickMenu()
    {
        Debug.Log("MenuController click");
        SceneManager.LoadScene("MenuScene");
    }
}
