using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAttackPlace : MonoBehaviour
{
    private int damagePoison; // Poison damage per iteration
    private int iterationCountPoison; // How long poison will be active
    private float iterationTime; // Time betwen iterations
    private float radiusHit = 0;

    public void Initialize(int damagePoison, int iterationCountPoison, float iterationTime, float radiusHit, float life)
    {
        this.damagePoison = damagePoison;
        this.iterationCountPoison = iterationCountPoison;
        this.iterationTime = iterationTime;
        this.radiusHit = radiusHit;

        StartCoroutine(DestroyByTime(life));
    }

    private IEnumerator DestroyByTime(float life)
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }

    private void Update()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, DataManager.ENEMY_LAYER_MASK);
        foreach (Collider target in targets)
        {
            if(target.GetComponent<StatusEffectManager>() != null && !target.GetComponent<Enemy>().isPoison)
                target.GetComponent<StatusEffectManager>().ApplyBurn(iterationCountPoison, damagePoison, iterationTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
    }
}
