using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject finishPrefab;
    [SerializeField] private GameObject respawnPrefab;
    [SerializeField] private GameObject wellPrefab;
    [SerializeField] private GameObject characterPrefab;

    

    public static int[,] titleArray;
    public static int countR = 12;
    public static int countC = 10;
    
    private DataManager.CordinatesStruct spawnCordinates;
    private DataManager.CordinatesStruct finishCordinates;
    //private List<CordinatesStruct> spawnCordinates;
    //private List<CordinatesStruct> finishCordinates;

    private void Start()
    {
        /*
         * -1 - well, Enemy can not move
         * 0 - ground, Enemy can move
         * -2 - character who damage enemy
         * -3 - enemy spawn possition
         * -4 - finish 
         */
        DataManager.titleArray = new int[,]
        {
            { -1, -1, -1,-1,-1,-1,-1,-1,-1,-1 },
            { -1, -1, -3,-1,-1,-1,-2,-1,-1,-1 },
            { -1, -1, 0,-1,-1,-1,-1,-1,-1,-1 },
            { -1, -1, 0,-1, 0, 0, 0,-1,-1,-1 },
            { -1, -1, 0, 0, 0, -1,0,-1,-1,-1 },
            { -1, -1, -1,-1,-1,-1,0,-1,-2,-1 },
            { -1, -1, -1,-1,-1,-1,0,-1,-1,-1 },
            { -1, -1, -2,-1, 0, 0, 0,-1,-1,-1 },
            { -1, -1, -1,-1,0,-1,0,-1,-1,-1 },
            { -1, 0, 0, 0, 0, 0, 0, -1, -1, -1 },
            { -1, -4, -1,-1,-1,-1,-1,-1,-1,-1 },
            { -1, -1, -1,-1,-1,-1,-1,-1,-1,-1 }
        };

        //spawnCordinates = new List<CordinatesStruct>();
        //finishCordinates = new List<CordinatesStruct>();
        //spawnCordinates = new CordinatesStruct();
        //finishCordinates = new CordinatesStruct();

        for (int i = 0; i < countR; i++)
            for (int j = 0; j < countC; j++)
            {
                GameObject title = null;

                if (DataManager.titleArray[i, j] == 0)
                    title = Instantiate(groundPrefab);
                else if (DataManager.titleArray[i, j] == -2)
                    title = Instantiate(characterPrefab);
                else if (DataManager.titleArray[i, j] == -3)
                {
                    title = Instantiate(respawnPrefab);
                    //spawnCordinates.Add(new CordinatesStruct(i, j));
                    spawnCordinates = new DataManager.CordinatesStruct(i, j);
                    DataManager.titleArray[i, j] = 0;
                }
                else if (DataManager.titleArray[i, j] == -4)
                {
                    title = Instantiate(finishPrefab);
                    finishCordinates = new DataManager.CordinatesStruct(i, j);
                    //finishCordinates.Add(new CordinatesStruct(i, j));
                }
                else title = Instantiate(wellPrefab);

                if (title != null)
                {
                    title.transform.SetParent(transform);
                    title.transform.localPosition = new Vector3(j - Screen.width / 310, -10, i - Screen.height / 310 );
                }
            }
        /*
        foreach(CordinatesStruct tempSpawnForBuildingWay in spawnCordinates)
        {
            findWay(tempSpawnForBuildingWay);
        }
        */
        DataManager.WayToFinish = new List<DataManager.CordinatesStruct>();
        findWay(spawnCordinates, 1);
        
           for (int i = 0; i < DataManager.titleArray.GetLength(0); i++, Debug.Log("\n"))
               for (int j = 0; j < DataManager.titleArray.GetLength(1);j++) 
                Debug.Log(DataManager.titleArray[i,j]);
        
    }

    private void findWay(DataManager.CordinatesStruct temp—or, int i)
    {

        if (DataManager.titleArray[temp—or.xPosition, temp—or.yPosition] == -4)
        {
            DataManager.titleArray[temp—or.xPosition, temp—or.yPosition] = i;
            buildWayBack(new(temp—or.xPosition, temp—or.yPosition), i);
            return;
        }

        if(DataManager.titleArray[temp—or.xPosition, temp—or.yPosition] == 0)
        {
            DataManager.titleArray[temp—or.xPosition, temp—or.yPosition] = i;
            
            if (temp—or.xPosition - 1 > -1)
                findWay(new DataManager.CordinatesStruct(temp—or.xPosition - 1, temp—or.yPosition), i+1);
            if (temp—or.xPosition + 1 < DataManager.titleArray.GetLength(0))
                findWay(new DataManager.CordinatesStruct(temp—or.xPosition + 1, temp—or.yPosition), i+1);
            if (temp—or.yPosition - 1 > -1)
                findWay(new DataManager.CordinatesStruct(temp—or.xPosition, temp—or.yPosition - 1), i+1);
            if (temp—or.yPosition + 1 < DataManager.titleArray.GetLength(1))
                findWay(new DataManager.CordinatesStruct(temp—or.xPosition, temp—or.yPosition + 1), i+1);
        }            
    }

    private void buildWayBack(DataManager.CordinatesStruct temp—or, int i)
    {

        if (DataManager.titleArray[temp—or.xPosition, temp—or.yPosition] == 1)
        {

            return;
        }
        if (temp—or.xPosition - 1 > -1)
        {
            if (DataManager.titleArray[temp—or.xPosition - 1, temp—or.yPosition] + 1 == i)
            {
                DataManager.WayToFinish.Add(new DataManager.CordinatesStruct(0, 1));
                buildWayBack(new DataManager.CordinatesStruct(temp—or.xPosition - 1, temp—or.yPosition), i - 1);
                return;
            }
        }
        if (temp—or.xPosition + 1 < DataManager.titleArray.GetLength(0))
        {
            if (DataManager.titleArray[temp—or.xPosition + 1, temp—or.yPosition] + 1 == i)
            {
                DataManager.WayToFinish.Add(new DataManager.CordinatesStruct(0, -1));
                buildWayBack(new DataManager.CordinatesStruct(temp—or.xPosition + 1, temp—or.yPosition), i - 1);
                return;
            }
        }
        if (temp—or.yPosition - 1 > -1)
        {
            if (DataManager.titleArray[temp—or.xPosition, temp—or.yPosition - 1] + 1 == i)
            {
                DataManager.WayToFinish.Add(new DataManager.CordinatesStruct(-1, 0));
                buildWayBack(new DataManager.CordinatesStruct(temp—or.xPosition, temp—or.yPosition - 1), i - 1);
                return;
            }
        }
            
        if (temp—or.yPosition + 1 < DataManager.titleArray.GetLength(1))
        {
            if (DataManager.titleArray[temp—or.xPosition, temp—or.yPosition + 1] + 1 == i)
            {
                DataManager.WayToFinish.Add(new DataManager.CordinatesStruct(1, 0));
                buildWayBack(new DataManager.CordinatesStruct(temp—or.xPosition, temp—or.yPosition + 1), i - 1);
                return;
            }
        }
    }

}
