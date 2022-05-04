using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameLevel : MonoBehaviour
{
    public static float speed = 3f;
    public static float size = 0.35f;
    public static int level = 1;
    private GameObject[] fishes;
    private void Start()
    {
        fishes = GameObject.FindGameObjectsWithTag("Fish");
        fishes[0].GetComponent<Image>().color = Color.white;
    }
    public void SelectLevel()
    {
        if (Pond.currentLevel == 1)
        {
            GameObject ClickFish = EventSystem.current.currentSelectedGameObject;
            if (ClickFish.name == "Fish_S")
            {
                level = 1;
                speed = 3f;
                size = 0.35f;
            }
            else if (ClickFish.name == "Fish_M")
            {
                level = 2;
                speed = 5f;
                size = 0.25f;
            }
            else if (ClickFish.name == "Fish_L")
            {
                level = 3;
                speed = 7f;
                size = 0.15f;
            };
            fishes[0].GetComponent<Image>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f);
            fishes[1].GetComponent<Image>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f);
            fishes[2].GetComponent<Image>().color = new Color(0.7843137f, 0.7843137f, 0.7843137f);
            fishes[level-1].GetComponent<Image>().color = Color.white;
            GameObject.FindWithTag("Pond").GetComponent<Pond>().Restart();
        }
        print(fishes[0].GetComponent<Image>().color);
        print(fishes[1].GetComponent<Image>().color);
        print(fishes[2].GetComponent<Image>().color);
    }
}
