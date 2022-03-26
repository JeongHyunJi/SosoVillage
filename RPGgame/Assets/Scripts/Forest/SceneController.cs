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
        if (Hearts.heart != 0)
        {
            Debug.Log(other.gameObject);
            if (other.gameObject.CompareTag("treants"))
                SceneManager.LoadScene("GameShooting");
            else if (other.gameObject.CompareTag("moles"))
                SceneManager.LoadScene("GameDodugi");
        }
        else
            Debug.Log("하트가 0개입니당. 게임을 할 수 없습니당.");
    }
}
