using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
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

    public static int[,] titleArray;
    public static int money;

    public static List<CordinatesStruct> WayToFinish;
}
