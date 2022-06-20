using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 0;
    public float _speed = 1;

    [SerializeField] private int damage = 1;
    [SerializeField] private ProgressBar healthBar;
    [SerializeField] private float FasterProcent;
    [SerializeField] private GameObject explosionPrefub;

    public float scale { get; private set; }

    private int max_Health;
    private Tween moveTween;
    private Tween jumpTween;
    private Animator animator;

    void Start()
    {
        max_Health = Health;
        animator = GetComponent<Animator>();

        int _listIndex = PathManager.GetRandomPathNumber();

        scale = transform.localScale.x;

        _speed = PathManager.GetPathDuration(_listIndex) - (float)(PathManager.GetPathDuration(_listIndex) * FasterProcent * 0.01);
        animator.SetFloat("Velocity", _speed * Time.deltaTime * 5);
        moveTween = transform.DOPath(PathManager.GetRandomPath(_listIndex), _speed).SetLookAt(-1f).OnComplete(() =>
        {
            CakeControllerScript.EatCake(damage);
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
        ResourcesManager.Change(ResourceType.EnemyCount, 1);
        if (DataManager.IsLastWave && DataManager.NumberOfDeathEnemies >= DataManager.NumberOfAllEnemies)
        {
            CakeControllerScript.EndGame(true);
        }
    }

    public int GetHealthInProccent()
    {
        return max_Health * 100 / Health;
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
        animator?.SetBool("IsDansing", true);
        moveTween?.Pause();
        StartCoroutine(waitToPlayAnim(duration));
    }

    private IEnumerator waitToPlayAnim(int duration)
    {
        yield return new WaitForSeconds(duration);
        animator?.SetBool("IsDansing", false);
        moveTween?.Play();
    }

}
