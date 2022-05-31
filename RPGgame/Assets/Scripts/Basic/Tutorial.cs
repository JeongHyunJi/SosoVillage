using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tutorialPanel;
    public GameObject[] Page;
    private int curPage = 0;
    private void Start()
    {
        tutorialPanel = GameObject.FindGameObjectWithTag("Tutorial");
        //if(savePlayer.tutorial)
        tutorialPanel.SetActive(true);
        for (int i = 1; i < Page.Length; i++)
        {
            Page[i].SetActive(false);
        }
    }

    public void TutorialClose()
    {
        tutorialPanel.SetActive(false);
    }

    public void NextPage()
    {
        if (curPage + 1 < Page.Length)
        {
            Page[curPage].SetActive(false);
            curPage++;
            Page[curPage].SetActive(true);
        }
    }
}
