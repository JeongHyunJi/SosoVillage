using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void GoToFishingGame()
    {
        SceneManager.LoadScene("GameFishing");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("treants"))
            SceneManager.LoadScene("GameShooting");
        else if (other.gameObject.CompareTag("moles"))
            SceneManager.LoadScene("GameDodugi");
    }
}
