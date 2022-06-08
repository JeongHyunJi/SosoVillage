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
            SavePosition.setPosition(this.gameObject);
            SceneManager.LoadScene("Room");
        }

        if (other.tag == "baking")
        {
            print("baking");
            SavePosition.setPosition(this.gameObject);
            SceneManager.LoadScene("GameCookingReal");
            print("베이킹 입장요");
        }

        if (other.tag == "store")
        {
            print("store");
            SavePosition.setPosition(this.gameObject);
            SceneManager.LoadScene("Store");
        }
    }
}
