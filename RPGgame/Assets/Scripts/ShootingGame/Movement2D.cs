using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed = 0;
    public Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        Debug.Log(direction);
        moveDirection = direction;
    }
}
