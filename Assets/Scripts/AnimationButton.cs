using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
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
        shineSequence.Append(shineRect.DOAnchorPosX(400f, 1f).SetEase(Ease.InQuad));
        shineSequence.SetLoops(-1, LoopType.Restart);
        shineTween = shineSequence;
    }

    private void OnDestroy()
    {
        shineTween?.Kill();
    }

    public void DeactibvateAnimatedButton()
    {
        shineTween?.Pause();
        if (gameObject.GetComponent<Button>())
        {
            gameObject.GetComponent<Button>().enabled = false;
        }
        gameObject.GetComponent<Image>().color = Color.grey;
    }

    public void ActivateAnimatedButton()
    {
        shineTween?.Play();
        gameObject.SetActive(true);
        if (gameObject.GetComponent<Button>())
        {
            gameObject.GetComponent<Button>().enabled = true;
        }
        gameObject.GetComponent<Image>().color = Color.white;
    }
}
