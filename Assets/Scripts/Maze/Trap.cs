using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if(SoundManager.Instance.VibrationEnabled)
            Handheld.Vibrate();
            
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.2f);
        Ball.Instance.ResetBall();
        yield return null;
    }
}
