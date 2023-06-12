using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUpsSpawn : MonoBehaviour
{
    private bool doneWaiting = false;
    
    public GameObject[] powerUps;


    void Update()
    {
        if(doneWaiting == false)
        {
            doneWaiting = true;
            StartCoroutine(WaitFifteen());
        }

        IEnumerator WaitFifteen()
        {
            int randomIndex = Random.Range(0, powerUps.Length);
            Vector3 randomSpawnPos = new Vector3(Random.Range(-5, 5), 5, Random.Range(-5, 5));

            Instantiate(powerUps[randomIndex], randomSpawnPos, Quaternion.identity);
            
            yield return new WaitForSeconds(1);
            doneWaiting = false;
        }
    }


}
