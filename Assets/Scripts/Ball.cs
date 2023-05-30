using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rigidbody;

    public void SetKinematic(bool state)
    {
        _rigidbody.isKinematic = state;
    }
}
