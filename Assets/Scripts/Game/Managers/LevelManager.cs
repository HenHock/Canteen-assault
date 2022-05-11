using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int[] startHealthByLevel;

    private void Start()
    {
        ResourcesManager.Change(ResourceType.Life, startHealthByLevel[Random.Range(0, startHealthByLevel.Length)]);
        ResourcesManager.Change(ResourceType.Money, 500);
    }
}
