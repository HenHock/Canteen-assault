using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
    public int costToBuy; 
    public int costToUpgrade; 
    public int attackDamage; 
    [Range(1,100)] public float moneyBackPercentage; 
    public GameObject nextLevelPrefab; 

    [SerializeField, Range(1.5f, 10f)] public float radiusHit = 1.5f; 
    [SerializeField, Range (0f, 10f)] public float attackSpeed = 2f;
    [SerializeField] private Transform turret; 
    [SerializeField] private GameObject shotPrefab;

    private GameObject shot;
    [SerializeField] private TargetPoint target;
    
    private float nextShoot = 0;

    private void Update()
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
            shot.GetComponent<Shot>().damage = attackDamage;
            shot.GetComponent<Shot>().target = target.transform;
            shot.transform.rotation = turret.transform.rotation;
            shot.transform.position = turret.transform.TransformPoint(Vector3.forward * 1.5f);
            nextShoot = Time.time + (1000 / attackSpeed) / 1000;
        }
    }

    // Find target to shoot
    private bool isAcquireTarger()
    {
        DataManager.targets = Physics.OverlapSphere(transform.position, radiusHit, DataManager.ENEMY_LAYER_MASK);

        if (DataManager.targets.Length > 0)
        {
            target = DataManager.targets[DataManager.targets.Length-1].GetComponent<TargetPoint>();
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
        ResourcesManager.Change(ResourceType.Money, costToBuy * moneyBackPercentage * 0.01f);
        Destroy(gameObject);
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
