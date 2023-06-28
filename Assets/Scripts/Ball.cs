using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;
    [SerializeField]
    ParticleSystem _bubbleTrail;
    [SerializeField]
    float velocityThreshold = 0.1f;

    [SerializeField]
    Rigidbody _rigidbody;
    public Vector3 initialPosition;

    private void Awake()
    {
        Instance = this;
    }

	private void Update()
	{
        BubbleLogic();
	}

	void BubbleLogic()
    {
        if (_rigidbody.velocity.magnitude <= velocityThreshold)
        {
            if (_bubbleTrail.isPlaying)
            {
                _bubbleTrail.Stop();
            }
        }
        else 
        {
            if (!_bubbleTrail.isPlaying) 
            {
                _bubbleTrail.Play();
            }
        }
    }

    public void ResetBall()
    {
        transform.position = StartPoint.Instance.transform.position;
    }

    public void SetKinematic(bool state)
    {
        _rigidbody.isKinematic = state;
    }
}
