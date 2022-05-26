using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Hello
public class Enemy : MonoBehaviour
{
    public int Health = 0;
    private float _speed;
    [SerializeField] private int damage = 1;
    [SerializeField] private ProgressBar healthBar;
    [SerializeField] private float FasterProcent;
    [SerializeField] private GameObject explosionPrefub;
    public float scale { get; private set; }

    private Tween moveTween;
    private Tween jumpTween;

    void Start()
    {
        scale = transform.localScale.x;
        int _listIndex = PathManager.GetRandomPathNumber();
        _speed = PathManager.GetPathDuration(_listIndex)-(float)(PathManager.GetPathDuration(_listIndex) * FasterProcent * 0.01);
        //Debug.Log(_speed + "speed");
        //Debug.Log(PathManager.GetRandomPath(_listIndex).Length);
        moveTween = transform.DOPath(PathManager.GetRandomPath(_listIndex), _speed).SetLookAt(-1f).OnComplete(() =>
        {
            Cake.EatCake(damage);
            EnemyDestroy();
        });
        //Debug.Log(moveTween + "is anim");
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
        Debug.Log(DataManager.NumberOfAllEnemies + " " + DataManager.NumberOfDeathEnemies);
        ResourcesManager.Change(ResourceType.EnemyCount, 1);
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
        jumpTween?.Kill();

        DropMoney makeMoneyDrop = gameObject.GetComponent<DropMoney>();
        makeMoneyDrop.Drop(transform.position);

        Instantiate(explosionPrefub, transform.position, Quaternion.Euler(0, 0, 0));

        if(gameObject.CompareTag("Boss"))
        {
            SlowMotionController.startSlowMo();
        }

        EnemyDestroy();
    }

    public void Dancing(int duration)
    {
        moveTween?.Pause();
        jumpTween = transform.DOJump(transform.position, 0.5f, duration, duration);
        StartCoroutine(waitToPlayAnim(duration));
    }

    private IEnumerator waitToPlayAnim(int duration)
    {
        yield return new WaitForSeconds(duration);
        moveTween?.Play();
    }

}
