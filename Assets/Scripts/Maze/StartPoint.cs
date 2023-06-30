using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StartPoint : MonoBehaviour
{
    public static StartPoint Instance;

    [SerializeField] GameObject ballPrefab;
    [SerializeField] AudioSource _AudioSource;
    [SerializeField] AudioClip _AudioClip;
    public bool _ballIsSpawnd { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    IEnumerator Start()
    {
        _AudioSource.clip = _AudioClip;
        _AudioSource.Play();

        _ballIsSpawnd = false;
        yield return new WaitForSeconds(1f);

        Instantiate(ballPrefab, transform.position, Quaternion.identity);
        _ballIsSpawnd = true;
        yield return null;
    }
}
