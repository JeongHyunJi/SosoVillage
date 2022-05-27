using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void MoveToHome()
    {
        if (SceneManager.GetActiveScene().name == "Store")
        {
            SceneManager.LoadScene(Variables.asName);
        }
        //SavePosition.currentPosition = new Vector2(6.5f, -16);
        else { SceneManager.LoadScene("Home"); }
    }
}
