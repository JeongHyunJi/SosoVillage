using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Variables.asName = sceneName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotoHome()
    {
        if (sceneName != "Home")
        {
            SavePosition.currentPosition = new Vector2(6.5f, -16);
            SceneManager.LoadScene("Home");
        }
    }
    public void GotoForest()
    {
        if (sceneName != "Forest")
        {
            SavePosition.currentPosition = new Vector2(0, 0);
            SceneManager.LoadScene("Forest");
        }
    }
    public void GotoStore()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        SavePosition.SaveCurrentPosition(player);
        SceneManager.LoadScene("Store");
    }
}
