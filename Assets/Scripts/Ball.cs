using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rigidbody;
    private Vector3 initialPosition;
    private void Start()
    {
        initialPosition = transform.position;
    }

    public void ResetBall()
    {
        transform.position = initialPosition;
    }

    public void SetKinematic(bool state)
    {
        _rigidbody.isKinematic = state;
    }
}
