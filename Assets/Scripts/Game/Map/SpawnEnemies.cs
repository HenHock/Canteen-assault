using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private int timeSpawn = 1;
    //[SerializeField] private List<EnemyWave> enemyWavesList;
    private List<EnemyWave> enemyWavesList;

    private GameObject _enemy;
    
    void Start()
    {
        enemyWavesList = LevelManager.returnEnemyList(DataManager.currentLevel);
        ResourcesManager.Change(ResourceType.NumberWave, CountAllEnemiesAtWave());
        StartCoroutine(SpawnWaves());
    }
    private int CountAllEnemiesAtWave()
    {
        int sum = 0;
        foreach(EnemyWave squard in enemyWavesList)
        {
            for (int k = 0; k < squard.squardsList.Count; k++)
            {
                sum += squard.squardsList[k].numberOfEnemyinSquard;
            }
        }
        
        return sum;
    }

    
    private IEnumerator SpawnWaves()
    {
       
        for (int k=0; k<enemyWavesList.Count;k++)
        {            
            yield return new WaitForSeconds(enemyWavesList[k].delayTime);
            MakeListEnemies(k);
            MixList(enemyWavesList[k].allSquardsList);
            yield return StartCoroutine(SpawnSquards(k));

        }
        DataManager.IsLastWave = true;
    }
  
    private void MakeListEnemies(int numberWave)
    {
        for (int numberSquard = 0; numberSquard < enemyWavesList[numberWave].squardsList.Count; numberSquard++)
        {
            int shouldSpawn = enemyWavesList[numberWave].squardsList[numberSquard].numberOfEnemyinSquard / enemyWavesList[numberWave].squardsList[numberSquard].numberInGroupe;
            for (int k = 0; k < shouldSpawn; k++)
            {
                enemyWavesList[numberWave].allSquardsList.Add(enemyWavesList[numberWave].squardsList[numberSquard]);
            }
        }
    }

    private void MixList(List<EnemyWave.Squard> listForMix)
    {
        for (int i = 0; i < listForMix.Count; i++)
        {
            EnemyWave.Squard tmp = listForMix[0];
            listForMix.RemoveAt(0);
            listForMix.Insert(Random.Range(0,listForMix.Count), tmp);
        }
    }

    private IEnumerator SpawnSquards(int numberWave)
    {
        for (int numberSquard = 0; numberSquard < enemyWavesList[numberWave].allSquardsList.Count; numberSquard++)
        {
                SpawnGroupe(numberWave, numberSquard);
                yield return new WaitForSeconds(timeSpawn);
        }
    }
    private void SpawnGroupe(int numberWave, int numberSquard)
    {
        for (int k = 0; k < enemyWavesList[numberWave].allSquardsList[numberSquard].numberInGroupe; k++)
        {
            _enemy = Instantiate(enemyWavesList[numberWave].allSquardsList[numberSquard].typeOfEnemy);
            _enemy.transform.SetParent(transform);
            _enemy.transform.localPosition = new Vector3( 0, 0, 0);
            DataManager.NumberOfAllEnemies++;
            //ResourcesManager.Change(ResourceType.EnemyCount, -1);
        }
    }

}
