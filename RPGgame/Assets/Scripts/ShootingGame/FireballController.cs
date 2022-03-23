using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        player = GameObject.Find("player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //player animation 실행 - playercontroller
            //player 피감 - playercontroller
            player.TakeDamage(1f);
            Destroy(gameObject);
        }
    }
}
