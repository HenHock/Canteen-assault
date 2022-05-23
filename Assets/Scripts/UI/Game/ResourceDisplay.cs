using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceDisplay : MonoBehaviour
{
    [SerializeField] private ResourceType type;
    [SerializeField] private TMP_Text amountLabel;

    private void Awake()
    {
        ResourcesManager.OnResourcesAmountChanged += HandleCurrencyAmountChanged;
    }

    private void Start()
    {
        HandleCurrencyAmountChanged(type, ResourcesManager.Get(type));
    }

    private void OnDestroy()
    {
        ResourcesManager.OnResourcesAmountChanged -= HandleCurrencyAmountChanged;
    }

    private void HandleCurrencyAmountChanged(ResourceType resource, float value)
    {
        if (resource == type)
            amountLabel.text = value.ToString();
    }
}
