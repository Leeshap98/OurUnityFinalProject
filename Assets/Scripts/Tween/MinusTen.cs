using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class MinusTen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI minusTen;

    private float cycleLength = 3f;

    void Start()
    {
        //minusTen.DOMove(new Vector3(-2, 0, 0), cycleLength);
        minusTen.DOFade(00f, 2f);
    }
}
