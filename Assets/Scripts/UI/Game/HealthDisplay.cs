using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{/*
    [SerializeField] private TMP_Text lifeLabel;
    [SerializeField] private ResourceItemSO resource;

    private void Awake()
    {
        ResourcesManager.OnResourcesAmountChanged += HandleLifeAmountChanged;
    }

    private void Start()
    {
        HandleLifeAmountChanged(resource, ResourcesManager.Get(resource));
    }

    private void OnDestroy()
    {
        ResourcesManager.OnResourcesAmountChanged -= HandleLifeAmountChanged;
    }

    private void HandleLifeAmountChanged(ResourceItemSO item, float value)
    {
        if (resource != item)
            return;

        lifeLabel.text = value.ToString();
    }
    */
}
