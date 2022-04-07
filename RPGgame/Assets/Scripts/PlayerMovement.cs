using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SavePosition
{
    public static Vector2 currentPosition = new Vector2(6,-16);

    public static void setPosition(GameObject gameObject){
        SavePosition.currentPosition = gameObject.transform.position;
        SavePosition.currentPosition.y = SavePosition.currentPosition.y - (float)0.5;
    }
}

public class PlayerMovement : MonoBehaviour
{
    private Movement2D movement2D;
    private SpriteRenderer render;
    private Animator animator;
    private BoxCollider2D boxCollider;

    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        movement2D = GetComponent<Movement2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        transform.position = SavePosition.currentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("DirX", x);
        animator.SetFloat("DirY", y);
        animator.SetBool("Walking", true);
        if (x > 0 && y == 0)
        {
            animator.SetFloat("Right", 1);
            animator.SetFloat("Up", 0);
            render.flipX = true;
        }
        else if (x < 0 && y == 0)
        {
            render.flipX = false;
            animator.SetFloat("Right", -1);
            animator.SetFloat("Up", 0);
        }
        else if (x == 0 && y > 0)
        {
            animator.SetFloat("Right", 0);
            animator.SetFloat("Up", 1);
        }
        else if (x == 0 && y < 0)
        {
            animator.SetFloat("Right", 0);
            animator.SetFloat("Up", -1);
        }
        if (x == 0 && y == 0)
            animator.SetBool("Walking", false);

        RaycastHit2D hit;
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(x * movement2D.moveSpeed * Time.deltaTime, y * movement2D.moveSpeed * Time.deltaTime);
        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, layerMask);
        boxCollider.enabled = true;
        if (hit.transform != null)
        {
            x = 0;
            y = 0;
        }

        movement2D.MoveTo(new Vector3(x, y, 0));
    }
}
