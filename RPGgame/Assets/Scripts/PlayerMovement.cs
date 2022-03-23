using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Movement2D movement2D;
    private SpriteRenderer render;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        movement2D = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("DirX", x);
        animator.SetFloat("DirY", y);
        animator.SetBool("Walking", true);
        if (x == 0 && y == 0)
            animator.SetBool("Walking", false);

        if (x > 0) //좌우반전으로 오른쪽으로 걷기
            render.flipX = true;
        else
            render.flipX = false;

        movement2D.MoveTo(new Vector3(x, y, 0));
    }
}
