using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static int[,] titleArray;
    public static Vector3 selectedPositionPlaceCharacterSpawn;
    public static UIController uIController;
    public static GameObject selectedCharacter;
    public static bool isPanel;
    public static int NumberOfAllEnemies { get; set; }
    public static int NumberOfDeathEnemies { get; set; }
    public static bool IsLastWave { get; set; }

    void Awake()
    {
        NumberOfAllEnemies = 0;
        NumberOfDeathEnemies = 0;
        IsLastWave = false;
    }
}
