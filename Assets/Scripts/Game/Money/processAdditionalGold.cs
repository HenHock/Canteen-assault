using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Assets.Scripts.ScriptableObjects;

public class processAdditionalGold : MonoBehaviour
{
    private int additionalGold;

    [SerializeField] private int timeLive = 0;
    [SerializeField] private ResourceItemSO resource;

    private Tween moveTween;

    void Start()
    {
        moveTween = transform.DOJump(transform.position, 0.5f, timeLive, timeLive);
        Destroy(gameObject, timeLive);
    }

    public void setAdditionalGold(int additionalGold)
    {
        this.additionalGold = additionalGold;
    }

    private void OnMouseDown()
    {
        ResourcesManager.Change(resource, additionalGold);
        additionalGoldDestroy();
    }

    private void additionalGoldDestroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        moveTween?.Kill();
    }
}
