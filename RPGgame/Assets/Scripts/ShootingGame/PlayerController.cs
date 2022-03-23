using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement2D movement2D;

    private SpriteRenderer render;
    private Animator animator;

    private BoxCollider2D boxCollider;
    public LayerMask layerMask;

    private TreantController enemy;
    public float playerHP = 10f;
    private ShootingManager shootingManager;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        movement2D = GetComponent<Movement2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        enemy = GameObject.Find("treant").GetComponent<TreantController>();
        shootingManager = GameObject.Find("GameManager").GetComponent<ShootingManager>();
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

    public void TakeDamage(float damage)
    {
        playerHP -= damage;
        Debug.Log("PlayerHP : " + playerHP);
        if(playerHP <= 0)
        {
            Debug.Log("Player Dead");
            enemy.StopEnemy();
            shootingManager.gameOver(false);
            Destroy(gameObject);
        }    
    }

    public void StopMove()
    {
        Destroy(gameObject);
    }

}
