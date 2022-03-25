using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class Hearts
{
    public static int heart = 5;
}

public class HeartController : MonoBehaviour
{
    public int num;
    public Sprite Lheart;
    public Sprite Dheart;
    Image thisImg;
    // Start is called before the first frame update
    void Start()
    {
        thisImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (num <= Hearts.heart) 
        {
            thisImg.sprite = Lheart;
        }
        else
        {
            thisImg.sprite = Dheart;
        }
    }
}