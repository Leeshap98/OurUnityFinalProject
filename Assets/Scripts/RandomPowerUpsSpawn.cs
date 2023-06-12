using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUpsSpawn : MonoBehaviour
{
    public GameObject[] powerUps;

    private bool fire = false;

    void Update()
    {
        if(fire == false)
        {
            fire = true;
            StartCoroutine(FirePowerUp());
        }
    }

    IEnumerator FirePowerUp()
    {
        int randomIndex = Random.Range(0, powerUps.Length);
        Vector3 randomSpawnPos = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));

        Instantiate(powerUps[randomIndex], randomSpawnPos, Quaternion.identity);

        yield return new WaitForSeconds(15);
        fire = false;
    }
}
