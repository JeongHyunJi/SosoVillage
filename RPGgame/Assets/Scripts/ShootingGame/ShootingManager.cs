using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingManager : MonoBehaviour
{
    private PlayerController player;
    private TreantController enemy;
    private float playerStartHP;
    private float enemyStartHP;

    public Slider slider_playerHP;
    public Slider slider_enemyHP;

    public Image player_image;
    public Image enemy_image;

    private bool gameGoing = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").GetComponent<PlayerController>();
        enemy = GameObject.Find("treant").GetComponent<TreantController>();
        playerStartHP = player.playerHP;
        enemyStartHP = enemy.treantHP;
        Color playerColor = player_image.color;
        playerColor.a = 0;
        player_image.color = playerColor;
        Color enemyColor = enemy_image.color;
        enemyColor.a = 0;
        enemy_image.color = enemyColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameGoing)
        {
            player_image.transform.position = player.transform.position;
            enemy_image.transform.position = enemy.transform.position;
            slider_playerHP.value = player.playerHP / playerStartHP;
            slider_enemyHP.value = enemy.treantHP / enemyStartHP;
        }
    }

    public void gameOver(bool isPlayerWin)
    {
        gameGoing = false;
        Hearts.heart--;
        if(isPlayerWin)
        {
            Color playerColor = player_image.color;
            playerColor.a = 1f;
            player_image.color = playerColor;
            slider_enemyHP.gameObject.SetActive(false);
        }
        else
        {
            Color enemyColor = enemy_image.color;
            enemyColor.a = 1f;
            enemy_image.color = enemyColor;
            slider_playerHP.gameObject.SetActive(false);
        }
    }
}
