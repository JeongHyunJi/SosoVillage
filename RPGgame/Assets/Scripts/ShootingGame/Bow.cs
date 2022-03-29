using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float attackRate = 0.5f;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartShooting();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            StopShooting();
        }
    }

    public void StartShooting()
    {
        StartCoroutine("TryAttack");
    }
    
    public void StopShooting()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while(true)
        {
            Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(attackRate);
            
        }
    }
}
