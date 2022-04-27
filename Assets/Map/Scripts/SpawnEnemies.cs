using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefub;
    [SerializeField] private int timeSpawn;
    GameObject enemy;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemy = Instantiate(enemyPrefub);
        enemy.transform.SetParent(transform);
        enemy.transform.localPosition = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        i++;
        if (i%timeSpawn == 0)
        {
            enemy = Instantiate(enemyPrefub);
            enemy.transform.SetParent(transform);
            enemy.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
