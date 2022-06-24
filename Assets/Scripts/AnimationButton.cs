using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class AnimationButton : MonoBehaviour
{
    [SerializeField] private RectTransform shineRect;
    
    //
    private Tween shineTween;
    // Start is called before the first frame update
    void Start()
    {

        Sequence shineSequence = DOTween.Sequence().SetUpdate(true);
        shineSequence.Append(DOVirtual.DelayedCall(Random.Range(1f, 3f), null));
        shineSequence.Append(shineRect.DOAnchorPosX(250f, 1f).SetEase(Ease.InQuad));
        shineSequence.SetLoops(-1, LoopType.Restart);
        shineTween = shineSequence;
    }

    private void OnDestroy()
    {
        shineTween?.Kill();
    }
}
