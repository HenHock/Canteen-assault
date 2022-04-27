using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTemplate : MonoBehaviour
{
    public int damage { private get; set; }
    public float speed { private get; set; } = 2;

    public void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.gameObject.tag,"Enemy"))
        {
            EnemyTemplate enemy = other.gameObject.GetComponent<EnemyTemplate>();
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

}
