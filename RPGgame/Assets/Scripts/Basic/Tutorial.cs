using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
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
        tutorialPanel = GameObject.FindGameObjectWithTag("Tutorial");
        if (savePlayer.GetTutorial(sceneNum))
        {
            tutorialPanel.SetActive(true);
            for (int i = 1; i < Page.Length; i++)
            {
                Page[i].SetActive(false);
            }
            backIcon.SetActive(false);
            savePlayer.SetTutorial(sceneNum);
        }
        else
        {
            tutorialPanel.SetActive(false);
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
