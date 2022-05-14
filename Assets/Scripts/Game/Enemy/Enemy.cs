using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 0;
    public float _speed { get; private set; }
    [SerializeField] private int damage = 1;
    [SerializeField] private ProgressBar healthBar;
    [SerializeField] private float FasterProcent;

    private Tween moveTween;

    void Start()
    {
        int _listIndex = PathManager.GetRandomPathNumber();
        _speed = PathManager.GetPathDuration(_listIndex)-(float)(PathManager.GetPathDuration(_listIndex) * FasterProcent * 0.01);

        moveTween = transform.DOPath(PathManager.GetRandomPath(_listIndex), _speed).SetLookAt(-1f).OnComplete(() =>
        {
            Cake.EatCake(damage);
            EnemyDestroy();
        });

        healthBar.Initialize(Health);
    }

    private void EnemyDestroy()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        moveTween?.Kill();
        DataManager.NumberOfDeathEnemies++;
        if (DataManager.IsLastWave && DataManager.NumberOfDeathEnemies >= DataManager.NumberOfAllEnemies)
        {
            Cake.EndGame(true);
        }
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

    

}
