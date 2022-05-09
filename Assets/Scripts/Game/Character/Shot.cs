using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public int damage { private get; set; }
    public float speed { private get; set; }

    public void OnTriggerEnter(Collider other)
    {
        if (string.Equals(other.gameObject.tag,"Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
        }
        else if (!string.Equals(other.gameObject.tag, "Character"))
            Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

}
