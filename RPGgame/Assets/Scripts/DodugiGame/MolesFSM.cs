using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoleState { UnderGround, MoveUp, MoveDown}

public class MolesFSM : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public float MoveTime = 0;
    private MoveMoles movemoles;
    private MoleMagager molemanager;
    public MoleState MoleState { private set; get; }

    private void Awake()
    {
        movemoles = GetComponent<MoveMoles>();
        molemanager = GetComponent<MoleMagager>();
        ChangeState(MoleState.UnderGround);
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
                MoveTime = 0;
                ChangeState(MoleState.UnderGround);
            }
            yield return null;
        }
    }

   public void mole_click()
    {
        Debug.Log("Click");
        if (MoleState.ToString() == "MoveUp" || MoleState.ToString() == "MoveDown")
        {
            molemanager.PlusScore();
        }
        else
            return;
    }
}
