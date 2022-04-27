using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour
{
    [SerializeField] private int Heath = 0;
    [SerializeField] private int Speed = 0;
    private Vector3 target;
    private int i;

    void Start()
    {
        target = new Vector3(0, 0, 0);
        i = DataManager.WayToFinish.Count - 1;
    }

    void Update()
    {
        if (i == 0)
        {
            //eat cake
            EnemyDeath();
        }
        transform.Translate(DataManager.WayToFinish[i].xPosition * Time.deltaTime*(-1), 0, DataManager.WayToFinish[i].yPosition * Time.deltaTime*(-1));
    }

    void OnTriggerExit(Collider other)
    {

        if (string.Equals(other.gameObject.tag, "GameBoard"))
        { 
            i--;
        }
    }

    public void TakeDamage(int _damage)
    {
        Heath -= _damage;
        if (Heath <= 0)
            EnemyKilled();
    }

    private void EnemyKilled()
    {
        DropMoney makeMoneyDrop = gameObject.GetComponent<DropMoney>();
        makeMoneyDrop.Drop(transform.position);
        EnemyDeath();
    }

    private void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
