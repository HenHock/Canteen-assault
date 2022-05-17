using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefub;
    public int damage { set; get; }
    public float speed = 5;
    public Transform target { set; private get; }
    [SerializeField, Range(0.1f,4f)] private float radiusHit = 1;

    public void OnTriggerEnter(Collider other)
    {
        if (!string.Equals(other.transform.tag, "Character") || other.transform.GetComponent<processAdditionalGold>() != null)
        {
            Instantiate(explosionPrefub, transform.position, Quaternion.Euler(0, 0, 0));
            Hurt();
            Destroy(gameObject);
        }
    }

    void Hurt()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit);
        
        if(targets.Length > 0){
            foreach(Collider target in targets)
            {
                if (string.Equals(target.gameObject.tag, "Enemy"))
                {
                    Enemy enemy = target.gameObject.GetComponent<Enemy>();
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    void Update()
    { 
        if(target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        else Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
    }
}
