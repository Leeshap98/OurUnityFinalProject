using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUpsSpawn : MonoBehaviour
{
    private bool createNewPowerUp = false;

    public GameObject[] powerUps;

    void Update()
    {
        if(createNewPowerUp == false)
        {
            createNewPowerUp = true;

            StartCoroutine(MakeNewPowerUp());
        }
    }

    IEnumerator MakeNewPowerUp()
    {
        yield return new WaitForSeconds(5);

        int randomIndex = Random.Range(0, powerUps.Length);
        Vector3 randomSpawnPos = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));

        Instantiate(powerUps[randomIndex], randomSpawnPos, Quaternion.identity);

        createNewPowerUp = false;
    }
}
