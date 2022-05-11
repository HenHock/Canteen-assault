using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static Vector3 selectedPositionPlaceCharacterSpawn;
    [SerializeField] public static UIController uIController;
    public static GameObject selectedCharacter;
    public static bool isPanel;
    
    public static int NumberOfAllEnemies { get; set; } = 0;
    public static int NumberOfDeathEnemies { get; set; } = 0;
    public static bool IsLastWave { get; set; } = false;

    void Awake()
    {
        //uIController = GameObject.Find("UIController").GetComponent<UIController>();
        NumberOfAllEnemies = 0;
        NumberOfDeathEnemies = 0;
        IsLastWave = false;
    }
}
