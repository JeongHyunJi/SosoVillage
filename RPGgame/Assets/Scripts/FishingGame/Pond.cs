using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Restart();
    }

    public void Restart()
    {
        transform.localScale = new Vector2(GameLevel.size, 1f);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        transform.position = new Vector2(Random.Range(-8, 7), transform.localPosition.y);
    }
}
