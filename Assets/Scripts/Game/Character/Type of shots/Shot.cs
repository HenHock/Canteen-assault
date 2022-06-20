using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shot : MonoBehaviour
{
    public int damage { set; get; }
    public float speed = 5;

    public Transform target;

    [SerializeField, Range(0.1f,4f)] private float radiusHit = 1;
    [SerializeField] GameObject explosionPrefub;

    public void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.transform.tag, "Enemy") || string.Equals(other.transform.tag, "Boss"))
        {
            Hurt();
            if (explosionPrefub)
                Instantiate(explosionPrefub, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }

    public virtual void Hurt()
    {
        Enemy enemy = target.gameObject.GetComponent<Enemy>();
        enemy.TakeDamage(damage);
                    
        Destroy(gameObject);
    }

    void Update()
    {
        if(target != null)
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        else Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
    }
}
