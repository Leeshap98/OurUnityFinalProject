using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ClockAnimation : MonoBehaviour
{
    [SerializeField] PUA _pua;
    [SerializeField] MinusTen minus10;
    //[SerializeField] GameObject clockPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            UIManager.Instance.Timer -= 5;
            StartCoroutine(_pua.WaitFive());
            StartCoroutine(_pua.WaitToScaleDown());
        }

    }
}
