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

    [SerializeField] private float pathDuration;
    
    private Color color;

    private Tween moveTween;

    void Start()
    {
        color = GetComponent<Renderer>().material.color;
        moveTween = transform.DOPath(PathManager.GetRandomPath(), pathDuration).SetLookAt(-1f).OnComplete(() =>
        {
            Cake cake = GameObject.Find("Finish(Clone)").GetComponent<Cake>();
            if (cake != null)
                cake.eatCake(damage);

            EnemyDestroy();
        });

        healthBar.Initialize(Health);
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

        ChangeColor();
/*        Heath -= _damage;*/

        healthBar.Value -= ((float)_damage).ToPercent(healthBar.MaxValue);

        if (healthBar.Value <= 0)
            EnemyKilled();
    }

    private void /*IEnumerable*/ ChangeColor()
    {
        transform.GetComponent<MeshRenderer>().material.DOColor(Color.red, 1f);
        //yield return new WaitForSeconds(1f);
        transform.GetComponent<MeshRenderer>().material.DOColor(color, 1f);
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
