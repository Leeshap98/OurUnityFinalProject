using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class EndPoint : MonoBehaviour
{
    [SerializeField] AudioSource _AudioSource;
    [SerializeField] AudioClip _AudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _AudioSource.clip = _AudioClip;
            _AudioSource.Play();
            GameManager.Instance.EndLevel();
        }
    }
}
