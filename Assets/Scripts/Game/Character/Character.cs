using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
    public int level = 1;

    public int costToBuy;
    public int costToUpgrade;
    public int attackDamage;
    public GameObject nextLevelPrefab;

    [SerializeField, Range(1.5f, 10f)] public float radiusHit = 1.5f;
    [SerializeField, Range (1f, 10f)] public float attackSpeed = 2f;
    [SerializeField] private Transform turret;
    [SerializeField] private GameObject shotPrefab;

    private GameObject shot;
    private TargetPoint target;
    /*
     * 1 - default layer
     * 9 - our custom layer, which all enemies have
     * 1 << 9 - operation which bit shift by 9 elements from 0000000001 to 1000000000;
     * 1000000000 in decimal number system is equal to 512
     * ENEMY_LAYER_MASK contain value 512
     */
    private const int ENEMY_LAYER_MASK = 1 << 9;

    private void Update()
    {
        if (isAcquireTarger() && shot == null)
            onAttack();
    }

    public int GetCostToBuy()
    {
        return costToBuy;
    }

    public int GetCostToUpgrade()
    {
        return costToUpgrade;
    }

    public void onAttack()
    {
        var point = target.position;
        turret.LookAt(point);

        Ray ray = new Ray(turret.position, turret.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.GetComponent<Enemy>() != null)
            {
                if (shot == null)
                {
                    shot = Instantiate(shotPrefab);
                    shot.GetComponent<Shot>().damage = attackDamage;
                    shot.GetComponent<Shot>().target = hitObject.transform;
                    shot.transform.rotation = turret.transform.rotation;
                    shot.transform.position = turret.transform.TransformPoint(Vector3.forward * 1.5f);
                }
            }
        }
    }

    // Find target to shoot
    private bool isAcquireTarger()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, ENEMY_LAYER_MASK);
        if (targets.Length > 0)
        {
            target = Array.Find(targets, detactEnemy).GetComponent<TargetPoint>();
            return true;
        }

        target = null;
        return false;
    }

    private bool detactEnemy(Collider target)
    {
        if (target.GetComponent<Enemy>() != null)
            return true;
        return false;
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
