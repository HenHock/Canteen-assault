using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefub;
    [SerializeField] private int timeSpawn = 1000;
    private GameObject _enemy;
    int i = 0;

    void Start()
    {
        _enemy = Instantiate(enemyPrefub);
        _enemy.transform.SetParent(transform);
        _enemy.transform.localPosition = new Vector3(0, 0, 0);
    }

    void Update()
    {
        i++;
        if (i% timeSpawn == 0)
        {
            _enemy = Instantiate(enemyPrefub);
            _enemy.transform.SetParent(transform);
            _enemy.transform.localPosition = new Vector3(0, 0 , 0);
        }
    }
}
