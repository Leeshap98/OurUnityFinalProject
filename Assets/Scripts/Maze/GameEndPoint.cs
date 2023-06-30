using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class GameEndPoint : MonoBehaviour
{
    [SerializeField] AudioSource _AudioSource;
    [SerializeField] AudioClip _AudioClip;
    [SerializeField] GameObject _Particles;
    [SerializeField] GameObject _FinalPanel;
    [SerializeField] GameObject _PauseButton;
    [SerializeField] GameObject _AdsButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _AudioSource.clip = _AudioClip;
            _AudioSource.Play();
            _Particles.SetActive(true);
            _FinalPanel.SetActive(true);
            _PauseButton.SetActive(false);
            _AdsButton.SetActive(false);

        }
    }
}
