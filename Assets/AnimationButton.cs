using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimationButton : MonoBehaviour
{
    private Tween growAndSmallTween;

    private Sequence quence;
    // Start is called before the first frame update
    void Start()
    {
        Sequence quence = DOTween.Sequence();
        quence.Append(transform.DOScale(1.1f, 1f));
        quence.Append(transform.DOScale(1f, 1f));
        quence.SetLoops(-1);

           // .SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
