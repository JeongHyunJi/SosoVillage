using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMcontroller : MonoBehaviour
{
    AudioSource BGMaudioSource;

    // Start is called before the first frame update
    void Start()
    {
        this.BGMaudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void startBGM()
    {
        BGMaudioSource.Play();
    }
    public void stopBGM()
    {
        BGMaudioSource.Stop();
    }
}
