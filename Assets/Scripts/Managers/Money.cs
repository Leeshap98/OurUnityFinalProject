using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] PUA pua;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            UIManager.Instance.AddScore(5);
            StartCoroutine(pua.WaitFive());
            StartCoroutine(pua.WaitToScaleDown());
        }

       
    }
}
