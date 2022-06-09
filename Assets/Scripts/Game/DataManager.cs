using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;
    public static LevelInfo levelInfo;

    public static int currentLevel = 0;
    public static Transform selectedPositionPlaceCharacterSpawn;
    public static UIManager uIController;
    public static GameObject selectedCharacter;
    public static bool canMoveCamera;
    public static bool returnToGame;

    /*
     * 1 - default layer
     * 9 - our custom layer, which all enemies have
     * 1 << 9 - operation which bit shift by 9 elements from 0000000001 to 1000000000;
     * 1000000000 in decimal number system is equal to 512
     * ENEMY_LAYER_MASK contain value 512
     */

    public static int ENEMY_LAYER_MASK = 1 << 9;

    public static int NumberOfAllEnemies { get; set; } = 0;
    public static int NumberOfDeathEnemies { get; set; } = 0;
    public static bool IsLastWave { get; set; } = false;
    public static bool isNeedToDestroy { get; set; } = true;
    public static bool isRadiusAttackDisplay = true;
    public static GameObject activePanel;
    public static List<GameObject> radiusAttackObjects = new List<GameObject>();

    public static int prevWay = 0;

    public static int twentyProcentAmount = 0;

    private void Awake()
    { 
        levelInfo = _levelInfo;
    }
}
