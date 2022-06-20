using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAttackShot : Shot
{
    [SerializeField] private int countAttack;
    [SerializeField, Range(0.1f, 2f)] private float additionalRadiusAttack = 0.1f; // radius additional attack. 

    public override void Hurt()
    {
        --countAttack;
        if (countAttack > 0)
        {
            Enemy enemy = target.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);

            target = Physics.OverlapSphere(transform.position, additionalRadiusAttack, DataManager.ENEMY_LAYER_MASK)[0].transform;
        }
        else Destroy(gameObject);
    }
}
