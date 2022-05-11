using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] public float speed;
    [SerializeField, Range(0.1f,4f)] private float radiusHit = 1;

    public int GetDamage()
    {
        return damage;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!string.Equals(other.transform.tag, "Character"))
        {
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
                    transform.LookAt(target.transform.position);
                    enemy.TakeDamage(damage);
                }
            }
        }
    }

    void Update()
    {
        Hurt();
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
    }
}
