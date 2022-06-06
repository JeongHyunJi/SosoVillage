using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tutorial_inform : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject[] Panel;
    private void Start()
    {
        tutorialPanel = GameObject.FindGameObjectWithTag("Tutorial_info");
        tutorialPanel.SetActive(false);
        for (int i= 0; i < Panel.Length; i++)
        {
            Panel[i].SetActive(false);
        }
    }

    public void TutorialClose()
    {
        tutorialPanel.SetActive(false);
    }

    public void PrintPage()
    {
        string BtnName = EventSystem.current.currentSelectedGameObject.name;
        print(BtnName);
        if (BtnName == "FarmInfo")
        {
            tutorialPanel.SetActive(true);
            Panel[0].SetActive(true);
        }
    }
}
