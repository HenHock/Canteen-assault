using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScaleAnimationButton : MonoBehaviour
{
    private Tween scaleTween;
    // Start is called before the first frame update
    void Start()
    {
        scaleTween = transform.DOScale(   transform.localScale.x + 0.1f, 1f).SetLoops(-1, LoopType.Yoyo);

    }

    private void OnDestroy()
    {
        scaleTween?.Kill();
    }
}
