using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D monster;
    private SpriteRenderer render;
    private Animator animator;
    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        monster = GetComponent<Rigidbody2D>();
        Invoke("Think", 3);
    }

    private void FixedUpdate()
    {
        monster.velocity = new Vector2(x, y);
    }
    // Update is called once per frame
    void Think()
    {
        x = Random.Range(-1, 2);
        y = Random.Range(-1, 2);

        animator.SetFloat("DirX", x);
        animator.SetFloat("DirY", y);
        animator.SetBool("IsWalking", true);
        if (x == 0 && y == 0)
            animator.SetBool("IsWalking", false);

        if (x > 0) //좌우반전으로 오른쪽으로 걷기
        {
            render.flipX = false;
        }
        else
            render.flipX = true;

        monster.velocity = new Vector2(x, y);

        Invoke("Think", 3);
    }
}
