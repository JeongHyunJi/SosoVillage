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
            SceneManager.LoadScene("Room");
        }

        if (other.tag == "baking")
        {
            SceneManager.LoadScene("GameCookingPre");
        }

        if (other.tag == "store")
        {
            SceneManager.LoadScene("GameCookingPre");
        }
    }

}
