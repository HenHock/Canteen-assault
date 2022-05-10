using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int Health = 0;
    [SerializeField] private int damage = 1;
    [SerializeField] private ProgressBar healthBar;

    [SerializeField] private float FasterProcent;

    private Tween moveTween;

    void Start()
    {
        int _listIndex = PathManager.GetRandomPathNumber();
        float _speed = PathManager.GetPathDuration(_listIndex)-(float)(PathManager.GetPathDuration(_listIndex) * FasterProcent * 0.01);

        moveTween = transform.DOPath(PathManager.GetRandomPath(_listIndex), _speed).SetLookAt(-1f).OnComplete(() =>
        {
            Cake.EatCake(damage);

            EnemyDestroy();
        });

        healthBar.Initialize(Health);
    }

    private void OnDestroy()
    {
        moveTween?.Kill();
    }

    public void TakeDamage(int _damage)
    {

        healthBar.Value -= ((float)_damage).ToPercent(healthBar.MaxValue);

        if (healthBar.Value <= 0)
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
        if(DataManager.IsLastWave && DataManager.NumberOfDeathEnemies == DataManager.NumberOfAllEnemies)
        {
            Cake.EndGame(true);
        }
        Destroy(gameObject);
    }
}
