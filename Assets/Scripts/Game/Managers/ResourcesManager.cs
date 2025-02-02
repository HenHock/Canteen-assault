using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResourceType
{
    Life,
    Money,
    Star,
    EnemyCount,
    NumberWave
}
/*
 * Scrip for manage resources on scenes
 */
public static class ResourcesManager
{
    private static Dictionary<ResourceType, float> valueByResourceType;

    [RuntimeInitializeOnLoadMethod]
    private static void Initialize()
    {
        valueByResourceType = new Dictionary<ResourceType, float>
        {
            { ResourceType.Life, 0 },
            { ResourceType.Money, 0 },
            { ResourceType.EnemyCount, 0 },
            { ResourceType.NumberWave, 0 }
        };
        valueByResourceType.Add(ResourceType.Star, ES3.Load(SaveKeys.Star, 0f));
    }

    public static void Change(ResourceType resource, float amount)
    {
        valueByResourceType[resource] += amount;
        
        if (valueByResourceType[resource] < 0)
            valueByResourceType[resource] = 0;
        
        if (ResourceType.Star == resource)
            Save();
        
        OnResourcesAmountChanged?.Invoke(resource, valueByResourceType[resource]);
    }

    public static float Get(ResourceType resource)
    {
        return valueByResourceType[resource];
    }

    public static void Reset(ResourceType resource)
    {
        if (ResourceType.Star != resource)
            valueByResourceType[resource] = 0;
        OnResourcesAmountChanged -= CakeControllerScript.HandleLifeAmountChanged;
        OnResourcesAmountChanged?.Invoke(resource, valueByResourceType[resource]);
    }

    public static event Action<ResourceType, float> OnResourcesAmountChanged;

    public static void Save()
    {
        ES3.Save(SaveKeys.Star, valueByResourceType[ResourceType.Star]);
    }
}
