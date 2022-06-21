using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiAttackShot : Shot
{
    [SerializeField] private int countAttack;
    [SerializeField, Range(0.1f, 2f)] private float additionalRadiusAttack = 0.1f; // radius additional attack. 

    public override void Hurt()
    {
        target.gameObject.GetComponent<Enemy>().TakeDamage(damage);

        if(--countAttack <= 0)
            Destroy(gameObject);
        else if(target != Physics.OverlapSphere(transform.position, additionalRadiusAttack, DataManager.ENEMY_LAYER_MASK)[0].transform)
        {
            target = Physics.OverlapSphere(transform.position, additionalRadiusAttack, DataManager.ENEMY_LAYER_MASK)[0].transform;
        }else target = Physics.OverlapSphere(transform.position, additionalRadiusAttack, DataManager.ENEMY_LAYER_MASK)[1].transform;
    }
}
