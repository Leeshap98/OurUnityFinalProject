using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public static StartPoint Instance;
    [SerializeField]
    GameObject ballPrefab;
    public bool _ballIsSpawnd { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    IEnumerator Start()
    {
        _ballIsSpawnd = false;
        yield return new WaitForSeconds(1f);

        Instantiate(ballPrefab, transform.position, Quaternion.identity);
        _ballIsSpawnd = true;
        yield return null;
    }
}
