using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public static StartPoint Instance;
    public bool ballIsSpawned { get; private set; }

    [SerializeField] GameObject ballPrefab;


    private void Awake()
    {
        Instance = this;
    }
    IEnumerator Start()
    {
        ballIsSpawned = false;
        yield return new WaitForSeconds(1f);

        Instantiate(ballPrefab, transform.position, Quaternion.identity);
        ballIsSpawned = true;
        yield return null;
    }
}
