using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GameLevel : MonoBehaviour
{
    public static float speed = 3f;
    public static float size = 0.35f;

    public void SelectLevel()
    {
        if (Pond.currentLevel == 1)
        {
            GameObject ClickFish = EventSystem.current.currentSelectedGameObject;
            if (ClickFish.name == "Fish_S")
            {
                speed = 3f;
                size = 0.35f;
            }
            else if (ClickFish.name == "Fish_M")
            {
                speed = 5f;
                size = 0.25f;
            }
            else if (ClickFish.name == "Fish_L")
            {
                speed = 7f;
                size = 0.15f;
            }
            GameObject.FindWithTag("Pond").GetComponent<Pond>().Restart();
        }
    }
}
