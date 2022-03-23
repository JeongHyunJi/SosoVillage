using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private TreantController enemy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
        enemy = GameObject.Find("treant").GetComponent<TreantController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemy"))
        {
            //적 animaion 실행 - treantcontroller
            //적 피감 - treantcontroller
            enemy.TakeDamage(1f);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
}
