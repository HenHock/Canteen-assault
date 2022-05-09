using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWave
{
    [SerializeField] public int numberOfWave;
    [SerializeField] public int delayTime;
   // [SerializeField] public List<int> whichWavesShouldDieFirst;
    [SerializeField] public List<Squard> squardsList;
    [HideInInspector]public List<Squard> allSquardsList;

    [System.Serializable]
    public struct Squard
    {
        [SerializeField] public GameObject typeOfEnemy;
        [SerializeField] public int numberOfEnemyinSquard;
        [SerializeField] public int numberInGroupe;
    }
}
