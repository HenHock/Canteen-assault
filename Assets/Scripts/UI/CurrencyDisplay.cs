using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text amountLabel;

    private void Awake()
    {
        CurrencyManager.OnCurrencyAmountChanged += HandleCurrencyAmountChanged;
    }

    private void Start()
    {
        HandleCurrencyAmountChanged(CurrencyManager.CurrentAmount);
    }

    private void OnDestroy()
    {
        CurrencyManager.OnCurrencyAmountChanged -= HandleCurrencyAmountChanged;
    }

    private void HandleCurrencyAmountChanged(float value)
    {
        amountLabel.text = value.ToString();
    }
}
