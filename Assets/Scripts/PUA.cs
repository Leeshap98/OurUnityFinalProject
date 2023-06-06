using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PUA : MonoBehaviour
{
    private float cycleLength = 2f;

    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), cycleLength, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);

        // StartCoroutine(WaitToScaleDown());
        //  StartCoroutine(WaitFive());
        //הורדתי את זה כי אז הסמלים נעלמים לפני שמספיקים לגשת אליהם
        //צריך לראות איך עושים טעינה א סנכרונית שלהם על המה כדי שיפלו בלי קשר אחד לשני

    }

    IEnumerator WaitFive()
    {
        yield return new WaitForSeconds(5);
        Object.Destroy(this.gameObject);
    }

    IEnumerator WaitToScaleDown()
    {
        yield return new WaitForSeconds(4);
        transform.DOScale(new Vector3(0, 0, 0), 1f).SetEase(Ease.InBounce);
    }
}
