using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public AudioClip entrance;
    AudioSource audioSource;

    void PlaySound()
    {
        audioSource.clip = entrance;
        audioSource.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.audioSource = GetComponent<AudioSource>();
        if (other.tag == "house")
        {
            print("house");
            SavePosition.setPosition(this.gameObject);
            SceneManager.LoadScene("Room");
            PlaySound();
        }

        if (other.tag == "baking")
        {
            print("baking");
            SavePosition.setPosition(this.gameObject);
            SceneManager.LoadScene("GameCookingReal");
            PlaySound();
        }

        if (other.tag == "store")
        {
            print("store");
            SavePosition.setPosition(this.gameObject);
            SceneManager.LoadScene("Store");
            PlaySound();
        }
    }
}
