using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AutoMove : MonoBehaviour
{
    private Movement2D movement2D;

    private SpriteRenderer render;
    private Animator animator;

    private float timegoing = 0;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        movement2D = GetComponent<Movement2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timegoing += Time.deltaTime;
        if (timegoing <= 8)
        {
            animator.SetBool("Walking", true);
            animator.SetFloat("DirX", 1);
            render.flipX = true;
            movement2D.MoveTo(new Vector3(1, 0, 0));
        }
        else if (timegoing <= 9)
        {
            animator.SetBool("Walking", false);
            animator.SetFloat("DirX", 0);
            render.flipX = false;
            movement2D.MoveTo(new Vector3(0, 0, 0));
        }
        else if (timegoing <= 17)
        {
            animator.SetBool("Walking", true);
            animator.SetFloat("DirX", -1);
            render.flipX = false;
            movement2D.MoveTo(new Vector3(-1, 0, 0));
        }
        else if (timegoing <= 18)
        {
            animator.SetBool("Walking", false);
            animator.SetFloat("DirX", 0);
            render.flipX = false;
            movement2D.MoveTo(new Vector3(0, 0, 0));
        }
        else
        {
            timegoing = 0;
        }
    }
}
