using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverPanel;
    public Text gameoverText;

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
    }
    public void Gameover()
    {
        gameoverText.text = fishingButton.isSuccess ? "GAME CLEAR" : "GAMEOVER";
        gameoverPanel.SetActive(true);
        Hearts.heart--;
        Hearts.HeartControll();
        fishingButton.isSuccess = false;
    }

    public void BackToMap()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Forest");
    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameFishing");
    }
}
