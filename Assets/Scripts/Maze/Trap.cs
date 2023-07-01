using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Trap : MonoBehaviour
{
    [SerializeField] AudioSource _AudioSource;
    [SerializeField] AudioClip _AudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if(SoundManager.Instance.VibrationEnabled == true)
                Handheld.Vibrate();

            _AudioSource.clip = _AudioClip;
            _AudioSource.Play();

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
