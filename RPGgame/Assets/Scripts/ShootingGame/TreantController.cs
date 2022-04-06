using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreantController : MonoBehaviour
{
    public GameObject fireballPrefab;
    public float attackRate = 0.5f;

    private Movement2D movement2D;

    private SpriteRenderer render;
    private Animator animator;

    private BoxCollider2D boxCollider;
    public LayerMask layerMask;

    public float treantHP = 20f;
    private PlayerController player;
    private ShootingManager shootingManager;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        movement2D = GetComponent<Movement2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.Find("player").GetComponent<PlayerController>();
        shootingManager = GameObject.Find("GameManager").GetComponent<ShootingManager>();
        StartCoroutine("FollowPlayer");
        StartCoroutine("AttackPlayer");
    }


    private IEnumerator FollowPlayer()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            float dirX = 0;

            if (transform.position.x - player.transform.position.x >= 0.5)
            {
                dirX = -1;
            }
            else if (transform.position.x - player.transform.position.x <= -0.5)
            {
                dirX = 1;
            }
            animator.SetFloat("DirX", dirX);
            animator.SetBool("IsWalking", true);
            if (dirX == 0)
                animator.SetBool("IsWalking", false);

            if (dirX < 0) //좌우반전으로 오른쪽으로 걷기
                render.flipX = true;
            else
                render.flipX = false;

            RaycastHit2D hit;
            Vector2 start = transform.position;
            Vector2 end = start + new Vector2(dirX * movement2D.moveSpeed * Time.deltaTime, 0);
            boxCollider.enabled = false;
            hit = Physics2D.Linecast(start, end, layerMask);
            boxCollider.enabled = true;
            if (hit.transform != null)
            {
                dirX = 0;
            }

            movement2D.MoveTo(new Vector3(dirX, 0, 0));
            yield return new WaitForSeconds(attackRate);
        }
    }


    private IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(attackRate);

        }
    }

    public void TakeDamage(float damage)
    {
        treantHP -= damage;
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");
        if (treantHP <= 0)
        {
            Debug.Log("Treant Dead");
            //treant 죽는효과
            player.StopMove();
            shootingManager.GameOver(true);
            Destroy(gameObject);
        }
    }

    private IEnumerator HitColorAnimation()
    {
        render.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        render.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        render.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        render.color = Color.white;
    }

    public void StopEnemy()
    {
        movement2D.MoveTo(new Vector3(0, 0, 0));
        StopCoroutine("FollowPlayer");
        StopCoroutine("AttackPlayer");
    }

}
