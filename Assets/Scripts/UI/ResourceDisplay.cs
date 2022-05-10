using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private ResourceItemSO itemSO;
    [SerializeField] private TMP_Text amountLabel;

    private void Awake()
    {
        ResourcesManager.OnResourcesAmountChanged += HandleCurrencyAmountChanged;
    }

    private void Start()
    {
        HandleCurrencyAmountChanged(itemSO, ResourcesManager.Get(itemSO));
    }

    private void OnDestroy()
    {
        ResourcesManager.OnResourcesAmountChanged -= HandleCurrencyAmountChanged;
    }

    private void HandleCurrencyAmountChanged(ResourceItemSO resource, float value)
    {
        if (resource == itemSO)
            amountLabel.text = value.ToString();
    }
}
