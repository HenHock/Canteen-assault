using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourcesManager
{
    private static readonly Dictionary<ResourceItemSO, float> valueByResource = new Dictionary<ResourceItemSO, float>();

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        var resources = Resources.LoadAll<ResourceItemSO>("Data/Items/");

        foreach(var resource in resources)
        {
            valueByResource.Add(resource, 0);
        }
    }

    public static void Change(ResourceItemSO resource, float amount)
    {
        valueByResource[resource] += amount;
        OnResourcesAmountChanged?.Invoke(resource, valueByResource[resource]);
    }

    public static float Get(ResourceItemSO resource)
    {
        return valueByResource[resource];
    }

    public static event Action<ResourceItemSO, float> OnResourcesAmountChanged;
}
