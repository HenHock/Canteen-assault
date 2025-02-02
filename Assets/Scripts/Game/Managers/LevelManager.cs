using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct resourceManagerData
{
    public int startHealthByLevel;
    public int startMoneyByLevel;
    [SerializeField] public List<EnemyWave> enemyWavesList;
}

public class LevelManager : MonoBehaviour
{
    public static Func<int, List<EnemyWave>> returnEnemyList;
    public static Func<int> returnNumberOfLevels;

    public resourceManagerData[] resourceManagerStruct;

    private int getNumberOfLevels()
    {
        return resourceManagerStruct.Length;
    }

    private List<EnemyWave> getEnemyList(int i)
    {
        return resourceManagerStruct[i].enemyWavesList;
    }

    private void Awake()
    {
        DataManager.NumberOfAllEnemies = 0;
        DataManager.NumberOfDeathEnemies = 0;
        DataManager.IsLastWave = false;
        DataManager.canMoveCamera = true;
        DataManager.returnToGame = false;

        returnEnemyList = getEnemyList;
        returnNumberOfLevels = getNumberOfLevels;

    }

    private void Start()
    {
        ResourcesManager.Change(ResourceType.Life, resourceManagerStruct[DataManager.currentLevel].startHealthByLevel);
        ResourcesManager.Change(ResourceType.Money, resourceManagerStruct[DataManager.currentLevel].startMoneyByLevel);
        ResourcesManager.Reset(ResourceType.EnemyCount);
        ResourcesManager.Reset(ResourceType.NumberWave);

        DataManager.twentyProcentAmount = (int)ResourcesManager.Get(ResourceType.Life) / 5;
        Time.timeScale = 1;
    }
}
