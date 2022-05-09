using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image filler;
    [SerializeField] private float maxValue;

    [SerializeField] private float fillDUration;
    [SerializeField] private Ease fillEase;

    private Camera _mainCamera;
    private Tween _tween;

    private float _value;

    public float Value
    {
        get => _value;
        set
        {
            _value = value;
            _tween?.Kill();
            Debug.Log(_value);
            _tween = FillAnimation(_value).Play();
        }
    }

    public float MaxValue => maxValue;

    public void Initialize(float _maxValue)
    {
        maxValue = _maxValue;
        Value = maxValue.ToPercent(maxValue);
        _mainCamera = Camera.main;
    }

    private Sequence FillAnimation(float value)
    {
        Sequence sequence = DOTween.Sequence();

        filler.DOFillAmount(value, fillDUration).SetEase(fillEase);

        return sequence;
    }

    private void OnDestroy()
    {
        _tween?.Kill();
    }

    private void Update()
    {
        transform.LookAt(_mainCamera.transform.position);
    }
}
