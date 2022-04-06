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

    Vector2 v_one = new Vector2(140, 70);
    Vector2 v_two = new Vector2(140, 120);
    Vector2 v_three = new Vector2(120, 180);
    Vector2 v_four = new Vector2(120, 240);
    Vector2 v_finish = new Vector2(140, 100);

    public void Update()
    {
        if (ScoreCount.Score >= 6)
        {
            Plant.GetComponent<Image>().sprite = finish;
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_finish;
        }
        else if (ScoreCount.Score>=5)
        {
            Plant.GetComponent<Image>().sprite = five;
        }
        else if (ScoreCount.Score >= 4)
        {
            Plant.GetComponent<Image>().sprite = four;
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_four;
        }
        else if (ScoreCount.Score >= 3)
        {
            Plant.GetComponent<Image>().sprite = three;
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_three;
        }
        else if (ScoreCount.Score >= 2)
        {
            Plant.GetComponent<Image>().sprite = two;
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_two;
        }
        else if (ScoreCount.Score >= 1)
        {
            Plant.GetComponent<Image>().sprite = one;
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_one;
        }
    }
}
