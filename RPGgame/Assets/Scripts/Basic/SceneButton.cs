using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    private string sceneName;
    public AudioClip move;
    AudioSource audioSource;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Variables.asName = sceneName;
        this.audioSource = GetComponent<AudioSource>();
    }

    void Play()
    {
        audioSource.clip = move;
        audioSource.Play();
    }
    public void GotoHome()
    {
        if (sceneName != "Home")
        {
            SavePosition.currentPosition = new Vector2(6.5f, -16);
            SceneManager.LoadScene("Home");
            Play();
        }
    }
    public void GotoForest()
    {
        if (sceneName != "Forest")
        {
            SavePosition.currentPosition = new Vector2(0, 0);
            SceneManager.LoadScene("Forest");
            Play();
        }
    }
    public void GotoStore()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SavePosition.SaveCurrentPosition(player);
        SceneManager.LoadScene("Store");
        Play();
    }
}
