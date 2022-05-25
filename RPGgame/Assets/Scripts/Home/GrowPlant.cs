using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowPlant : MonoBehaviour
{
    public GameObject Plant;
    public FarmTimeController farmTimeController;

    public Sprite zero;
    public Sprite start;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;
    public Sprite finish;
    public int cur;

    Vector2 v_zero = new Vector2(100, 100);
    Vector2 v_start = new Vector2(100, 70);
    Vector2 v_one = new Vector2(140, 70);
    Vector2 v_two = new Vector2(140, 120);
    Vector2 v_three = new Vector2(120, 180);
    Vector2 v_four = new Vector2(120, 240);
    Vector2 v_finish = new Vector2(140, 100);

    private void Start()
    {
        farmTimeController = CountFarmTime.farmTimeControllers[cur];
    }
    public void Update()
    {
        if (farmTimeController.score >= 24)
        {
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_finish;
            Plant.GetComponent<Image>().sprite = finish;
        }
        else if (farmTimeController.score >= 20)
        {
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_four;
            Plant.GetComponent<Image>().sprite = five;
        }
        else if (farmTimeController.score >= 16)
        {
            Plant.GetComponent<Image>().sprite = four;
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_four;
        }
        else if (farmTimeController.score >= 12)
        {
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_three;
            Plant.GetComponent<Image>().sprite = three;
        }
        else if (farmTimeController.score >= 8)
        {
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_two;
            Plant.GetComponent<Image>().sprite = two;  
        }
        else if (farmTimeController.score >= 4)
        {
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_one;
            Plant.GetComponent<Image>().sprite = one;
        }
        else if(farmTimeController.score > 0)
        {
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_start;
            Plant.GetComponent<Image>().sprite = start;
        }
        else
        {
            transform.gameObject.GetComponent<RectTransform>().sizeDelta = v_zero;
            Plant.GetComponent<Image>().sprite = zero;
        }
    }
}
