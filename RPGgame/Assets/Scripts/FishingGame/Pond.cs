using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pond : MonoBehaviour
{
    public static int currentLevel = 1;
    private GameObject pond;
    private GameObject[] ponds;

    // Start is called before the first frame update
    void Start()
    {
        ponds = GameObject.FindGameObjectsWithTag("Pond");
        System.Array.Sort<GameObject>(ponds,(x, y) => string.Compare(x.name, y.name)); //이름기준 정렬
        pond = ponds[currentLevel - 1];
        currentLevel = 1;
        Restart();
    }

    public void Restart()
    {
        ponds = GameObject.FindGameObjectsWithTag("Pond");
        System.Array.Sort<GameObject>(ponds, (x, y) => string.Compare(x.name, y.name));
        pond = ponds[currentLevel - 1];
        pond.transform.localScale = new Vector2(GameLevel.size, 1f);
        pond.GetComponent<Renderer>().material.color = Color.blue;
        pond.transform.position = new Vector2(Random.Range(-4f, 3f), transform.localPosition.y);
    }
}
