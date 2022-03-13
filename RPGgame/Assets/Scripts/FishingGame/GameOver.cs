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
        fishingButton.isSuccess = false;
    }

    public void BackToMap()
    {
        gameoverPanel.SetActive(false);
        SceneManager.LoadScene("Forest");
    }

    public void PlayAgain()
    {
        gameoverPanel.SetActive(false);
        SceneManager.LoadScene("GameFishing");
    }
}
