using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shot : MonoBehaviour
{
    public GameObject character { get; set; }
    public int damage { set; get; }
    public float speed = 5;

    public Transform target;

    [SerializeField] private int health;
    [SerializeField, Range(0.1f,4f)] private float radiusHit = 1;
    [SerializeField, Range(0.1f, 2f)] private float additionalAttack = 0.1f; // радиус допольнительной атаки. 
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

    void Hurt()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, DataManager.ENEMY_LAYER_MASK);

        if (targets.Length > 0)
        {
            foreach (Collider target in targets)
            {
                if (string.Equals(target.gameObject.tag, "Enemy") || string.Equals(target.transform.tag, "Boss"))
                {
                    Enemy enemy = target.gameObject.GetComponent<Enemy>();
                    enemy.TakeDamage(damage);
                    --health;

                    if (health > 0)
                    {
                        Transform nextTarget = Physics.OverlapSphere(transform.position, additionalAttack, DataManager.ENEMY_LAYER_MASK)[0].transform;
                        if (nextTarget != this.target)
                            this.target = nextTarget;
                        else this.target = null;
                    }
                    else Destroy(gameObject);
                }
            }
        }
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
