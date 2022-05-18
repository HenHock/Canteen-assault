using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct resourceManager
{
    public int startHealthByLevel;
    public int startMoneyByLevel;
    [SerializeField] public List<EnemyWave> enemyWavesList;
}

public class LevelManager : MonoBehaviour
{
    public static Func<int, List<EnemyWave>> returnEnemyList;
    public static Func<int> returnNumberOfLevels;

    public resourceManager[] resourceManagerStruct;

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
        
        returnEnemyList = getEnemyList;
        returnNumberOfLevels = getNumberOfLevels;

        Debug.Log(DataManager.currentLevel);

        ResourcesManager.Change(ResourceType.Life, resourceManagerStruct[DataManager.currentLevel].startHealthByLevel);
        ResourcesManager.Change(ResourceType.Money, resourceManagerStruct[DataManager.currentLevel].startMoneyByLevel);
    }
}
