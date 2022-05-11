using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public int damage { private get; set; }
    public float speed { private get; set; }
    [SerializeField, Range(0.1f,4f)] private float radiusHit = 1;

    public void OnTriggerEnter(Collider other)
    {
        if(!string.Equals(other.transform.tag, "Character"))
            Destroy(gameObject);
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
        Hurt();
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
    }
}
