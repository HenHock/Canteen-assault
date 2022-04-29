using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public enum CharacterFileds
    {
        costToBuy,
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
   // public static List<CordinatesStruct> WayToFinish;

    void Awake()
    {
        uIController = GameObject.Find("UIController").GetComponent<UIController>();
    }
}
