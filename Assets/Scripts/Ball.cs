using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance;

    [SerializeField]
    Rigidbody _rigidbody;
    public Vector3 initialPosition;

    private void Awake()
    {
        Instance = this;
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
