using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    public float large = 0.15f;
    public float medium = 0.25f;
    public float small = 0.35f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(0.35f, 1f);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        transform.position = new Vector2(Random.Range(-9, 8),transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
