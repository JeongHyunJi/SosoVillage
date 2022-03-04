using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMoles : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.7f;
    private Vector3 movedirection = Vector3.zero;


    // Update is called once per frame
    void Update()
    {
        transform.position += movedirection * speed * Time.deltaTime;
    }

    public void Move(Vector3 direction)
    {
        movedirection = direction;
    }
}
