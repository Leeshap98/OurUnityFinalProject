using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Handheld.Vibrate();
            other.GetComponent<Ball>().ResetBall();
        }
    }
}
