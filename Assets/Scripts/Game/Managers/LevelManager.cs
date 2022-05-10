using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float[] startMoneyByLevel;

    private void Awake()
    {
        CurrencyManager.CurrentAmount = startMoneyByLevel[Random.Range(0, startMoneyByLevel.Length)];
    }
}
