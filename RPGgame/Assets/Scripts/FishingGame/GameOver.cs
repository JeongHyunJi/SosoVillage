using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameoverPanel;
    public Text gameoverText;
    public AudioClip winSound;
    public AudioClip loseSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameoverPanel.SetActive(false);
        this.audioSource = GetComponent<AudioSource>();
    }
    public void Gameover()
    {
        char[] levelChar = { 'S', 'M', 'L' }; 
        gameoverText.text = fishingButton.isSuccess ? "GAME CLEAR\n<color=yellow>you got "+levelChar[GameLevel.level-1]+ " Fish!</color>" : "GAMEOVER";
        gameoverPanel.SetActive(true);
        if (fishingButton.isSuccess)
            playSound("Win");
        else
            playSound("Lose");
        Variables.IsGameGoing = false;
        Hearts.heart--;
        Hearts.HeartControll();
        fishingButton.isSuccess = false;
    }

    public void BackToMap()
    {
        SceneManager.LoadScene("Forest");
    }

    public void PlayAgain()
    {
        GameLevel.level = 1;
        GameLevel.size = 0.35f;
        GameLevel.speed = 3f;
        SceneManager.LoadScene("GameFishing");
    }
    void playSound(string soundName)
    {
        switch (soundName)
        {
            case "Win":
                audioSource.clip = winSound;
                break;
            case "Lose":
                audioSource.clip = loseSound;
                break;
        }
        audioSource.Play();
    }
}
