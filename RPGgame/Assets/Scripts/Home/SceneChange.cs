using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "house")
        {
            print("house");
            SceneManager.LoadScene("Room");
        }

        if (other.tag == "baking")
        {
            print("baking");
            SceneManager.LoadScene("GameCookingPre");
        }

        if (other.tag == "store")
        {
            print("store");
            SceneManager.LoadScene("Store");
        }
    }
}
