using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public enum CharacterFileds
    {
        costToBuy,
        costToUpgrade,
        attackDamage,
        attackSpeed,
        radiusHit
    };
    /*
    public struct CordinatesStruct
    {
        public int xPosition;
        public int yPosition;

        public CordinatesStruct(int i, int j)
        {
            xPosition = i;
            yPosition = j;
        }
    };
    */
    public static int[,] titleArray;
    public static Vector3 selectedPositionPlaceCharacterSpawn;
    public static UIController uIController;
    public static GameObject selectedCharacter;
    public static bool isPanel;
    public static int NumberOfAllEnemies { get; set; } = 0;
    public static int NumberOfDeathEnemies { get; set; } = 0;
    public static bool IsLastWave { get; set; } = false;

    void Awake()
    {
        uIController = GameObject.Find("UIController").GetComponent<UIController>();
        NumberOfAllEnemies = 0;
        NumberOfDeathEnemies = 0;
        IsLastWave = false;
    }
}
