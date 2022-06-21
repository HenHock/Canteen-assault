using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAttackShot : RadiusAttackShot
{
    [SerializeField] private int damagePoison; // Poison damage per iteration
    [SerializeField] private int iterationCountPoison; // How long poison will be active
    [SerializeField] private float iterationTime; // Time betwen iterations
    [SerializeField] private float poisonPlaceLife; // How many seconds poison place will be exists

    public override void Hurt()
    {
        GameObject _radiusPrefab = Instantiate(radiusPrefab);
        _radiusPrefab.GetComponentInChildren<PoisonAttackPlace>().Initialize(damagePoison, iterationCountPoison, iterationTime, radiusHit, poisonPlaceLife);
        _radiusPrefab.transform.position = gameObject.transform.position;
        _radiusPrefab.transform.localScale = new Vector3(radiusHit * 0.65f, _radiusPrefab.transform.localScale.y, radiusHit * 0.65f);

        Destroy(gameObject);
    }
}
