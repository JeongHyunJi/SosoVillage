using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public Text coinText;
    SavePlayer savePlayer;

    private void Start()
    {
        savePlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<SavePlayer>();
    }
    void Update()
    {
        coinText.text = savePlayer.ReturnCoins() + " $";
    }
}
