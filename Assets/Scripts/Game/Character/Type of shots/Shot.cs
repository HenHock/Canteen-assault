using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shot : MonoBehaviour
{
    public int damage { set; get; }
    public float speed = 5;
    public Transform target;

    [SerializeField] private GameObject explosionPrefub;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            Hurt();
            if (explosionPrefub)
                Instantiate(explosionPrefub, transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (transform.position == target.position)
            Hurt();
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
}
