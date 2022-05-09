using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int Heath = 0;
    [SerializeField] private int damage = 1;

    [SerializeField] private float pathDuration;

    private Tween moveTween;

    void Start()
    {
        moveTween = transform.DOPath(PathManager.GetRandomPath(), pathDuration).SetLookAt(-1f).OnComplete(() =>
        {
            Cake cake = GameObject.Find("Finish(Clone)").GetComponent<Cake>();
            if (cake != null)
                cake.eatCake(damage);

            EnemyDestroy();
        });
    }

    private void OnDestroy()
    {
        moveTween?.Kill();
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.gameObject.tag, "Enemy"))
        {
            Debug.Log("!");

            //moveTween = transform.DOJump(transform.position, 0.1f, 1, 0.5f);
           // moveTween.Flip();
        }
        
    }*/

    public void TakeDamage(int _damage)
    {
        //moveTween = DOColor(Color.red, 0.2f);

        Heath -= _damage;
        if (Heath <= 0)
            EnemyKilled();
    }

    private void EnemyKilled()
    {
        moveTween?.Kill();
        DropMoney makeMoneyDrop = gameObject.GetComponent<DropMoney>();
        makeMoneyDrop.Drop(transform.position);
        EnemyDestroy();
    }

    private void EnemyDestroy()
    {
        DataManager.NumberOfDeathEnemies++;
        if(DataManager.IsLastWave && DataManager.NumberOfDeathEnemies== DataManager.NumberOfAllEnemies)
        {
            GameObject.Find("Finish(Clone)").GetComponent<Cake>().EndGame(true);
        }
        Destroy(gameObject);
    }
}
