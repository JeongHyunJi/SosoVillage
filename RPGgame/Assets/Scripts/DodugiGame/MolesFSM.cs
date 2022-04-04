using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoleState { UnderGround, MoveUp, MoveDown}

public class MolesFSM : MonoBehaviour
{

    public float MoveTime = 0;
    private MoveMoles movemoles;
    private MoleManager molemanager;
    private MoleSpawner molespawner;
    public MoleState MoleState { private set; get; }
    public bool isClickOk = false;

    private void Awake()
    {
        movemoles = GetComponent<MoveMoles>();
        ChangeState(MoleState.UnderGround);
        molemanager = GameObject.Find("MoleGameManager").GetComponent<MoleManager>();
        molespawner = GameObject.Find("molespawner").GetComponent<MoleSpawner>();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if(hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;
                if(isClickOk && molespawner.checkName(click_obj.name))
                {
                    molemanager.PlusScore();
                    isClickOk = false;
                }

            }
        }
    }

    public void ChangeState(MoleState newState)
    {
        StopCoroutine(MoleState.ToString());
        MoleState = newState;
        StartCoroutine(MoleState.ToString());
    }

    private IEnumerator UnderGround()
    {
        movemoles.Move(Vector3.zero);
        MoveTime = 0;
        yield return null;
    }

    private IEnumerator MoveUp()
    {
        movemoles.Move(Vector3.up);
        while (true)
        {
            MoveTime += Time.deltaTime;
            if(MoveTime >= 0.7f)
            {

                MoveTime = 0;
                ChangeState(MoleState.MoveDown);
            }
            yield return null;
        }
    }

    private IEnumerator MoveDown()
    {
        movemoles.Move(Vector3.down);
        while (true)
        {
            MoveTime += Time.deltaTime;
            if (MoveTime >= 0.7f)
            {
                isClickOk = false;
                MoveTime = 0;
                ChangeState(MoleState.UnderGround);
            }
            yield return null;
        }
    }

}
