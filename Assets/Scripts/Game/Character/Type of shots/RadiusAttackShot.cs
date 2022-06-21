using System.Collections;
using UnityEngine;

public class RadiusAttackShot : Shot
{
    [SerializeField] private protected GameObject radiusPrefab;
    [SerializeField, Range(1f, 4f)] private protected float radiusHit;

    public override void Hurt()
    {
        GameObject _radiusPrefab = Instantiate(radiusPrefab);
        _radiusPrefab.transform.position = gameObject.transform.position;
        _radiusPrefab.transform.Find("Circle").GetComponent<SphereCollider>().radius = radiusHit;
        _radiusPrefab.transform.localScale = new Vector3(radiusHit*0.65f, _radiusPrefab.transform.localScale.y, radiusHit * 0.65f);

        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, DataManager.ENEMY_LAYER_MASK);
        foreach (Collider target in targets)
        {
            target.GetComponent<Enemy>()?.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
    }
}
