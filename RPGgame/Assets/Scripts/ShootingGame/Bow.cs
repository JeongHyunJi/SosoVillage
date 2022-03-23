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
        if (Input.GetMouseButtonDown(0))
        {
            StartShooting();
        }
        else if (Input.GetMouseButtonUp(0))
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
