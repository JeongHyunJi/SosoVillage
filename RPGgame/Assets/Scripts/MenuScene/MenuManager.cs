using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update

    private void Start()
    {
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
}
