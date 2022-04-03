using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    public MolesFSM[] moles;
    public GameObject activeMole;
    private float spawnTime = 1.5f;
    private string moleName = " ";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnMole");
    }

    // Update is called once per frame
    private IEnumerator SpawnMole()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            int index = Random.Range(0, moles.Length);
            moles[index].ChangeState(MoleState.MoveUp);
            moleName = moles[index].name;
            moles[index].isClickOk = true;
            yield return new WaitForSeconds(spawnTime);
            moleName = " ";
            moles[index].isClickOk = false;
        }
    }

    public bool checkName(string checkname)
    {
        if (checkname == moleName)
            return true;
        return false;
    }

    public void EndGame()
    {
        StopAllCoroutines();
    }
    public void StartGame()
    {
        StartCoroutine("SpawnMole");
    }
}
