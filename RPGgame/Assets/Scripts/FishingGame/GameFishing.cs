using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFishing : MonoBehaviour
{
    
    public Rigidbody2D floatRigidbody; //낚시 찌
    public static bool isInPond = false; //연못에 있는지 판단
    Vector2 localScale;
    float width = 9f;

    bool direction = true;

    // Start is called before the first frame update
    void Start()
    {
        floatRigidbody = GetComponent<Rigidbody2D>();
        floatRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY; //y축 움직임 고정
    }

    private void FixedUpdate() //고정된 프레임마다 update
    {
        if (transform.position.x > width)
            direction = false;
        else if (transform.position.x < -width)
            direction = true;

        if (direction)
            GoRight();
        else
            GoLeft();
    }

    void GoRight()
    {
        localScale.x = 1f;
        floatRigidbody.velocity = new Vector2(GameLevel.speed, 0);
    }
    void GoLeft()
    {
        localScale.x = -1f;
        floatRigidbody.velocity = new Vector2(-GameLevel.speed, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("GameController"))
        {
            isInPond = true;
        }
        else
            isInPond = false;
    }
}
