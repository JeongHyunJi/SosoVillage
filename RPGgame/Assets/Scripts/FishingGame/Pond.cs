using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    public static int currentLevel = 1;
    public GameObject pond;
    // Start is called before the first frame update
    void Start()
    {
        pond = GameObject.FindGameObjectsWithTag("Pond")[currentLevel - 1];
        currentLevel = 1;
        Restart();
    }

    public void Restart()
    {
        pond = GameObject.FindGameObjectsWithTag("Pond")[currentLevel - 1];
        pond.transform.localScale = new Vector2(GameLevel.size, 1f);
        pond.GetComponent<Renderer>().material.color = Color.blue;
        pond.transform.position = new Vector2(Random.Range(-4f, 3f), transform.localPosition.y);
    }
}
