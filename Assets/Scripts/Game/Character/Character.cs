using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
    public int costToBuy { get; private set; }
    public int attackDamage { get; private set; }
    public float radiusHit { get; private set; }
    public float attackSpeed { get; private set; }

    public GameObject nextLevelPrefab;

    [SerializeField] private TeacherInfo teacherInfo;
    [SerializeField] private Transform turret; // ќбъект, который выполн€ет прицеливани€ и генарицию снар€да
    [SerializeField] private GameObject shotPrefab; 
    [SerializeField] private GameObject radiusHitDisplay; // ќбъект, который отображает радиус аттаки персонажа
    private GameObject radiusDisplay; // Ёкземпл€р объекта, отображает радиус аттаки персонажа

    private GameObject shot;
    private float nextShoot = 0;
    private TargetPoint target;

    private void Awake()
    {
        if(teacherInfo != null)
        {
            costToBuy = teacherInfo.costToBuy;
            attackDamage = teacherInfo.damage;
            attackSpeed = teacherInfo.attackSpeed;
            radiusHit = teacherInfo.attackRadius;
        }
    }

    /// <summary>
    /// ћетод, который генерирует объект, который отображает радиус атаки персонажа и устанавливает на позиции 0, 0, 0 относительно стола.
    /// </summary>
    public void SetRadiusAttackDisplay()
    {
        radiusDisplay = Instantiate(radiusHitDisplay);
        DataManager.radiusAttackObjects.Add(radiusDisplay);

        radiusDisplay.transform.localScale = new Vector3(radiusHit * 2.2f, 0.5f, radiusHit * 2.2f);
        radiusDisplay.transform.SetParent(transform.parent.parent);
        radiusDisplay.transform.localPosition = Vector3.zero;
        radiusDisplay.transform.localPosition = Vector3.up*0.1f;
        radiusDisplay.SetActive(DataManager.isRadiusAttackDisplay);
    }

    public TeacherInfo GetNextTeacherInfo()
    {
        return teacherInfo.nextTeacherInfo;
    }

    private void LateUpdate()
    {
        if (isAcquireTarger() || isTargetTrucked())
            onAttack();
    }

    private void onAttack()
    {
        if (target != null)
        {
            turret.LookAt(target.position);
            transform.LookAt(target.position);
        }

        if (Time.time > nextShoot)
        {
            shot = Instantiate(shotPrefab);
            shot.GetComponent<Shot>().target = target.transform;
            shot.GetComponent<Shot>().damage = attackDamage;
            shot.transform.rotation = turret.transform.rotation;
            shot.transform.position = turret.transform.TransformPoint(Vector3.forward * 1.5f);
            nextShoot = Time.time + (1000 / attackSpeed) / 1000;
        }
    }

    // Find target to shoot
    private bool isAcquireTarger()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, DataManager.ENEMY_LAYER_MASK);

        if (targets.Length > 0)
        {
            target = targets[targets.Length-1].GetComponent<TargetPoint>();
            return true;
        }

        target = null;
        return false;
    }
   

    private bool isTargetTrucked()
    {
        if (target == null)
            return false;
        else
        {
            Vector3 myPos = transform.localPosition;
            Vector3 targetPos = target.position;
            if (Vector3.Distance(myPos, targetPos) > radiusHit + target.colliderSize*target.enemy.scale) { 
                target = null;
                return false;
            }
        }

        return true;
    }

    public void DestroyCharacter()
    {
        ResourcesManager.Change(ResourceType.Money, costToBuy);
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Destroy(radiusDisplay);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 pos = turret.position;
        pos.y += 0.01f;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
        if(target != null)
        {
            Gizmos.color = Color.red;
            Debug.DrawLine(pos, target.position);
        }
    }
}
