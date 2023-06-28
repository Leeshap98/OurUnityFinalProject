using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUpsSpawn : MonoBehaviour
{
    [SerializeField] private GameObject clock;

    private bool doneWaiting = false;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if(doneWaiting == false)
        {
            doneWaiting = true;
            StartCoroutine(WaitFifteen());
        }

        IEnumerator WaitFifteen()
        {
            Vector3 randomSpawnPos = new Vector3(Random.Range(-3, 3), 5,(Random.Range(-3, 3)));

            Instantiate(clock, randomSpawnPos, Quaternion.identity);
            
            yield return new WaitForSeconds(15);
            doneWaiting = false;
        }
    }
}
