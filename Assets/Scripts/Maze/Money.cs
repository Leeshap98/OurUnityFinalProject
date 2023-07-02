using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Money : MonoBehaviour
{
    [SerializeField] AudioSource _AudioSource;
    [SerializeField] AudioClip _AudioClip;
    [SerializeField] PUA _pua;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _AudioSource.clip = _AudioClip;
            _AudioSource.Play();
            UIManager.Instance.AddScore(5);
            StartCoroutine(_pua.WaitFive());
            StartCoroutine(_pua.WaitToScaleDown());
        }

       
    }
}
