using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;

    public Vector3 initialPosition;

    [SerializeField] ParticleSystem bubbleTrail;
    [SerializeField] Rigidbody rgb;
    [SerializeField] float velocityThreshold = 0.1f;
    
    

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
        if (rgb.velocity.magnitude <= velocityThreshold)
        {
            if (bubbleTrail.isPlaying)
            {
                bubbleTrail.Stop();
            }
        }
        else 
        {
            if (!bubbleTrail.isPlaying) 
            {
                bubbleTrail.Play();
            }
        }
    }

    public void ResetBall()
    {
        transform.position = StartPoint.Instance.transform.position;
    }

    public void SetKinematic(bool state)
    {
        rgb.isKinematic = state;
    }
}
