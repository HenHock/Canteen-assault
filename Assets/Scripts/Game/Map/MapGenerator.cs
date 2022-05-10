using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private GameObject finishPrefab;
    [SerializeField] private GameObject respawnPrefab;
    [SerializeField] private GameObject wellPrefab;
    [SerializeField] private GameObject characterSpawnPlacePrefab;

    public static int[,] titleArray;
    public static int countR = 17;
    public static int countC = 10;
    /*
    private void Start()
    {
        /*
         *-1- well, Enemy can not move
         * 0- ground, Enemy can move
         *-2- character who damage enemy
         *-3- enemy spawn possition
         *-4- finish 
         *//*
        
        DataManager.titleArray = new int[,]
        {
            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1,-1,-1,-1,-1,-1,-3,-1 },
            {-1,-1,-1,-1,-1,-1,-1,-1,-0,-1 },
            {-1,-1,-1,-1,-1,-2,-0,-0,-0,-1 },
            {-1,-1,-0,-0,-0,-0,-0,-1,-1,-1 },
            {-1,-1,-0,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-2,-0,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-0,-1,-1,-2,-1,-1,-1,-1 },
            {-1,-1,-0,-1,-0,-0,-0,-1,-1,-1 },
            {-1,-1,-0,-0,-0,-1,-0,-1,-1,-1 },
            {-1,-1,-1,-1,-1,-1,-0,-2,-1,-1 },
            {-1,-1,-1,-1,-1,-1,-0,-1,-1,-1 },
            {-1,-1,-1,-1,-0,-0,-0,-1,-1,-1 },
            {-1,-1,-1,-1,-0,-2,-0,-1,-1,-1 },
            {-1,-0,-0,-0,-0,-0,-0,-1,-1,-1 },
            {-1,-4,-1,-1,-1,-1,-1,-1,-1,-1 },
            {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1 }
        };

        for (int i = countR-1; i >= 0; i--)
            for (int j = 0; j < countC; j++)
            {
                GameObject title = null;
                /* 
                 * 1px = 155 unity unit;
                 * V3(0,-0,-0) is the center of the screen, we find the top-left location to start drawing the map.
                 *//*
                Vector3 position = new Vector3(j- Screen.width / 2 / 155,-10, (i- Screen.height / 2 / 155)*(-1));

                if (DataManager.titleArray[i, j] == 0)
                {
                    title = Instantiate(groundPrefab);
                }
                else if (DataManager.titleArray[i, j] ==-2)
                    title = Instantiate(characterSpawnPlacePrefab);
                else if (DataManager.titleArray[i, j] ==-3)
                {
                    title = Instantiate(respawnPrefab);
                    DataManager.titleArray[i, j] = 0;
                }

                else if (DataManager.titleArray[i, j] ==-4)
                {
                    title = Instantiate(finishPrefab);
                }
                else title = Instantiate(wellPrefab);

                if (title != null)
                {
                    title.transform.SetParent(transform);
                    title.transform.localPosition = position;
                }
            }
    
    }*/
}
