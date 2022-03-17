using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D monster;
    public int moveHorizontal;
    public int moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        monster = GetComponent<Rigidbody2D>();
        Invoke("Think", 3);
    }

    private void FixedUpdate()
    {
        monster.velocity = new Vector2(moveVertical, moveHorizontal);
    }
    
    // Update is called once per frame
    void Think()
    {
        moveVertical = Random.Range(-1, 2);
        moveHorizontal = Random.Range(-1, 2);
        Invoke("Think", 3);
    }
}
