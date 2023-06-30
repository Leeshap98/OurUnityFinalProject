using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.Audio;

public class ClockAnimation : MonoBehaviour
{
    [SerializeField] AudioSource _AudioSource;
    [SerializeField] AudioClip _AudioClip;
    [SerializeField] PUA _pua;
    [SerializeField] TextMeshProUGUI minus10;
    //[SerializeField] MinusTen minus10;
    //[SerializeField] GameObject clockPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _AudioSource.clip = _AudioClip;
            _AudioSource.Play();
            UIManager.Instance.Timer -= 5;
            StartCoroutine(_pua.WaitFive());
            StartCoroutine(_pua.WaitToScaleDown());
            minus10.enabled = true;
            Debug.Log("TimeIsShowing");
        }

    }
}
