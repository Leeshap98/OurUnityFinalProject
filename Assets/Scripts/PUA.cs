using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PUA : MonoBehaviour
{
    private float cycleLength = 3f;

    private void Start()
    {
        transform.DORotate(new Vector3(360, 0, 0), cycleLength, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);

         StartCoroutine(WaitToScaleDown());
         StartCoroutine(WaitFive());
        
    }

    IEnumerator WaitFive()
    {
        yield return new WaitForSeconds(4);
        Object.Destroy(this.gameObject);
    }

    IEnumerator WaitToScaleDown()
    {
        yield return new WaitForSeconds(3);
        transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBounce);
    }
}
