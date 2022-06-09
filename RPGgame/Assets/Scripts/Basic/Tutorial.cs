using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject[] Page;
    private int curPage = 0;
    public GameObject nextIcon;
    public GameObject backIcon;
    private SavePlayer savePlayer;
    private void Start()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        print(sceneNum);
        savePlayer = FindObjectOfType<SavePlayer>();
        if (savePlayer.GetTutorial(sceneNum))
        {
            TutorialOpen();
            savePlayer.SetTutorial(sceneNum);
        }
        else
        {
            tutorialPanel.SetActive(false);
        }
    }
    public void TutorialOpen()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        tutorialPanel.SetActive(true);
        Page[0].SetActive(true);
        curPage = 0;
        for (int i = 1; i < Page.Length; i++)
        {
            Page[i].SetActive(false);
        }
        if(nextIcon != null)
        {
            nextIcon.SetActive(true);
        }
        if (backIcon != null)
        {
            backIcon.SetActive(false);
        }
    }
    public void TutorialClose()
    {
        tutorialPanel.SetActive(false);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    
    public void NextPage()
    {
        if (curPage + 1 < Page.Length)
        {
            Page[curPage].SetActive(false);
            curPage++;
            Page[curPage].SetActive(true);
            backIcon.SetActive(true);
        }
        if (curPage+1 == Page.Length)
        {
            nextIcon.SetActive(false);
        }
    }
    public void PreviousPage()
    {
        if (curPage >  0)
        {
            Page[curPage].SetActive(false);
            curPage--;
            Page[curPage].SetActive(true);
            nextIcon.SetActive(true);
        }
        if (curPage == 0)
        {
            backIcon.SetActive(false);
        }
    }
}
