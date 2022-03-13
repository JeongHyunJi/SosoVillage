using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeColor : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject go;

    void Start()
    {
        sr = go.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown("i"))
            //sr.material.color = new Color(0.3f, .04f, 0.7f);
            sr.material.color = new Color(0.6f, 0.4f, 0.0f);
    }
}
