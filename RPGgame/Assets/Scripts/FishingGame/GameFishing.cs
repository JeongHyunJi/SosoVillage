using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFishing : MonoBehaviour
{
    public static GameObject[] floats;
    public Rigidbody2D floatRigidbody; //낚시 찌
    public static bool isInPond = false; //연못에 있는지 판단
    Vector2 localScale;

    bool direction = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Hearts.heart == 0)
            SceneManager.LoadScene("Forest");
        if (Pond.currentLevel == 1)
        {   floats = GameObject.FindGameObjectsWithTag("Floats");
            floats[1].SetActive(false);
            floats[2].SetActive(false);
        }
        floatRigidbody = GetComponent<Rigidbody2D>();
        Stop();
        //Move();
    }

    private void FixedUpdate()
    {
        if (fishingButton.buttonControll)
            Stop();
        else
            Move();
    }

    public void Move() //fixedupdate 고정된 프레임마다 update
    {
        Variables.IsGameGoing = true;
        if (transform.position.x > 4.5)
            direction = false;
        else if (transform.position.x < -5.5)
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
    
    public void Stop()
    {
        floatRigidbody.velocity = new Vector2(0, 0);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Pond"))
        {
            isInPond = true;
        }
        else
            isInPond = false;
    }
}
