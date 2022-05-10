using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int[] startHealthByLevel;
    [SerializeField] private ResourceItemSO health;
    [SerializeField] private ResourceItemSO money;

    private void Start()
    {
        ResourcesManager.Change(health, startHealthByLevel[Random.Range(0, startHealthByLevel.Length)]);
        ResourcesManager.Change(money, 1000);
    }
}
