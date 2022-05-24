using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public int damage { set; get; }
    public Transform target { set; private get; }

    public float speed = 5;

    [SerializeField] private int health;
    [SerializeField, Range(0.1f,4f)] private float radiusHit = 1;
    [SerializeField] GameObject explosionPrefub;

    public void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.transform.tag, "Enemy"))
        {
            Hurt();
            if (explosionPrefub)
                Instantiate(explosionPrefub, transform.position, Quaternion.Euler(0, 0, 0));
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
                    health--;

                    if (health == 0)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }

    void Update()
    {
        if (DataManager.targets.Length > 0)
        {
            target = DataManager.targets[0].transform;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
    }
}
