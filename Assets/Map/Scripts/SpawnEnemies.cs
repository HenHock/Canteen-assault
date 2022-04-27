using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefub;
    GameObject enemy;
    int i = 0;

    void Start()
    {
        enemy = Instantiate(enemyPrefub);
        enemy.transform.SetParent(transform);
        enemy.transform.localPosition = new Vector3(0,0,0);
    }

    void Update()
    {
        i++;
        if (i%1000 == 0)
        {
            enemy = Instantiate(enemyPrefub);
            enemy.transform.SetParent(transform);
            enemy.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
