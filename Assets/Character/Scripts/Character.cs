using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
    [SerializeField] private int costToBuy;
    [SerializeField] private int costToUpgrade;
    [SerializeField] private int attackDamage;
    [SerializeField, Range(1.5f, 10f)]
        private float radiusHit = 1.5f;
    [SerializeField, Range (1f, 10f)]
        private float attackSpeed = 2f;
    [SerializeField] private Transform turret;
    [SerializeField] private GameObject shotPrefab;

    private GameObject shot;
    private TargetPoint target;
    private const int ENEMY_LAYER_MASK = 1 << 9; // 1 << 9 - Побитовый сдвиг на 9 элементов из 0000000001 -> 1000000000; 2^9 = 512

    private void Update()
    {
        if (isAcquireTarger())
            onAttack();
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
                    shot.GetComponent<Shot>().speed = attackSpeed;
                    shot.transform.position = turret.transform.TransformPoint(Vector3.forward * 1.5f);
                    shot.transform.rotation = turret.transform.rotation;
                }
            }
        }
    }

    private bool isAcquireTarger()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, ENEMY_LAYER_MASK);
        if (targets.Length > 0)
        {
            target = targets[0].GetComponent<TargetPoint>();
            return true;
        }

        target = null;
        return false;
    }

    public float getField(DataManager.CharacterFileds fileds)
    {
        if (fileds == DataManager.CharacterFileds.costToBuy)
            return costToBuy;
        else if(fileds == DataManager.CharacterFileds.attackDamage)
            return attackDamage;
        else if (fileds == DataManager.CharacterFileds.radiusHit)
            return radiusHit;
        else if(fileds == DataManager.CharacterFileds.attackSpeed)
            return attackSpeed;

        return 0;
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
