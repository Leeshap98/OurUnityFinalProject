using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PUA : MonoBehaviour
{
    private float cycleLength = 3f;

    private void Start()
    {
        transform.DOMoveY(0.7f, 0.5f);

        transform.DORotate(new Vector3(0, 360, 0), cycleLength, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);

        /* StartCoroutine(WaitToScaleDown());*/
       /*  StartCoroutine(WaitFive());*/
        
    }

   public IEnumerator WaitFive()
    {
        yield return new WaitForSeconds(2);
        Object.Destroy(this.gameObject);
    }

    public IEnumerator WaitToScaleDown()
    {
        transform.DOScale(new Vector3(0, 0, 0), 0.05f).SetEase(Ease.InBounce);
        yield return new WaitForSeconds(1);
        Object.Destroy(this.gameObject);
    }
}
