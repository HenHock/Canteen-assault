using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTemplate : MonoBehaviour
{
    public int Damage = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        // определение столкновения с двумя разноименными объектами
        if (other.gameObject.tag.Equals("Enemy"))
        {
            EnemyTemplate enemy = other.gameObject.GetComponent<EnemyTemplate>(); ;
            enemy.GetDamage(Damage);
        }
        Destroy(gameObject);
    }

}
