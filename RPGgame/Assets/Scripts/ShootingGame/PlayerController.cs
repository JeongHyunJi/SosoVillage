using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D movement2D;

    private Bow bow;

    private Animator animator;

    private BoxCollider2D boxCollider;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        movement2D = GetComponent<Movement2D>();
        bow = GetComponent<Bow>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
            transform.localScale = new Vector2(1f, 1f);


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

        if(Input.GetMouseButtonDown(0))
        {
            bow.StartShooting();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            bow.StopShooting();
        }
    }

}
