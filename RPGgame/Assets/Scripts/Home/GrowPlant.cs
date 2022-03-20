using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPlant : MonoBehaviour
{
    public GameObject Plant;
    public Text scoreText;

    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite finish;
    public void Change_image()
    {
        if (ScoreCount.Score >= 6)
        {
            Plant.GetComponent<Image>().sprite = finish;
        }
        else if (ScoreCount.Score>=5)
        {
            Plant.GetComponent<Image>().sprite = five;
        }
        else if (ScoreCount.Score >= 4)
        {
            Plant.GetComponent<Image>().sprite = four;
        }
        else if (ScoreCount.Score >= 3)
        {
            Plant.GetComponent<Image>().sprite = three;
        }
        else if (ScoreCount.Score >= 2)
        {
            Plant.GetComponent<Image>().sprite = two;
        }
        else if (ScoreCount.Score >= 1)
        {
            Plant.GetComponent<Image>().sprite = one;
        }
    }
}
