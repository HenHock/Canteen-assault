using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static int[,] titleArray;
    public static Vector3 selectedPositionPlaceCharacterSpawn;
    public static UIController uIController = GameObject.Find("UIController").GetComponent<UIController>();
}
