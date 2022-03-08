using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleSpawner : MonoBehaviour
{
    public MolesFSM[] moles;
    private float spawnTime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnMole");
    }

    // Update is called once per frame
    private IEnumerator SpawnMole()
    {
        while (true)
        {
            int index = Random.Range(0, moles.Length);
            moles[index].ChangeState(MoleState.MoveUp);
            yield return new WaitForSeconds(spawnTime);
        }
    }
    public void EndGame()
    {
        StopAllCoroutines();
    }
}
