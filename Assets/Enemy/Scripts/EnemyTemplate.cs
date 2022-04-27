using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour
{
    [SerializeField] private int Heath = 0;
    [SerializeField] private int Speed = 0;
    [SerializeField] private int Reward = 0;
    private Vector3 target;
    private int i;
  //  private const float criticalDistance = 0.01f;

    void Start()
    {
        target = new Vector3(0, 0, 0);
        i = DataManager.WayToFinish.Count - 1;
        Debug.Log(i);
    }

    void Update()
    {
        if (i == 0)
        {
            //eat cake
            EnemyDeath();
        }

        //transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);

        transform.Translate(DataManager.WayToFinish[i].xPosition * Time.deltaTime*(-1), 0, DataManager.WayToFinish[i].yPosition * Time.deltaTime*(-1));

       /* float distance = Vector3.Distance(point.pos, transform.position);
        

        if (distance < criticalDistance)
        {
            //DO SOMETHING
        }
        Debug.Log(i--);
        //i--;
        */
    }

    void OnTriggerExit(Collider other)
    {

        if (string.Equals(other.gameObject.tag, "GameBoard"))
        { 
            i--;
//            Debug.Log("I was here!");
        }
  //      Debug.Log("I was there!");
    }

    public void TakeDamage(int _damage)
    {
        Heath -= _damage;
        if (Heath <= 0)
            EnemyDeath();
    }

    public void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
