using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text coinText;
    GameObject savePlayer;

    private void Start()
    {
        savePlayer = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        coinText.text = "X " + savePlayer.GetComponent<SavePlayer>().ReturnCoins();
    }
}
