using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PUA : MonoBehaviour
{
    private float cycleLength = 2f;

    private void Start()
    {
        //Do Tween Rotation
        transform.DORotate(new Vector3(0, 360, 0), cycleLength, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
<<<<<<< Updated upstream
=======

         StartCoroutine(WaitToScaleDown());
         StartCoroutine(WaitFive());
>>>>>>> Stashed changes
    }

    IEnumerator WaitFive()
    {
        yield return new WaitForSeconds(5);
        Object.Destroy(this.gameObject);
    }

    IEnumerator WaitToScaleDown()
    {
        yield return new WaitForSeconds(4);
        //Do Tween Scale
        transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBounce);
    }
}
