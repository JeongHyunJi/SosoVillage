using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public AudioClip entrance;
    AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D other)
    {
        this.audioSource = GetComponent<AudioSource>();
        if (other.tag == "house")
        {
            print("house");
            SavePosition.setPosition(this.gameObject);
            SceneManager.LoadScene("Room");
            audioSource.clip = entrance;
            audioSource.Play();
        }

        if (other.tag == "baking")
        {
            print("baking");
            SavePosition.setPosition(this.gameObject);
            SceneManager.LoadScene("GameCookingReal");
            audioSource.clip = entrance;
            audioSource.Play();
        }

        if (other.tag == "store")
        {
            print("store");
            SavePosition.setPosition(this.gameObject);
            SceneManager.LoadScene("Store");
            audioSource.clip = entrance;
            audioSource.Play();
        }
    }
}
