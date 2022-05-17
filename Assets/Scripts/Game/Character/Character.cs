using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
    public int costToBuy; // Стоимость покупки персонажа
    public int costToUpgrade; // Стоимость повышения уровня персонажа
    public int attackDamage; // Значение урона персонажа
    [Range(1,100)] public float moneyBackPercentage; // Процент денег, от покупки, который будет возвращен игроку при удаление персонажа
    public GameObject nextLevelPrefab; // Префаб на следующий уровень персонажа.

    [SerializeField, Range(1.5f, 10f)] public float radiusHit = 1.5f; // Радиус, в котором персонаж сможет стрелять.
    [SerializeField, Range (1f, 10f)] public float attackSpeed = 2f; // Скорость атаки персонажа
    [SerializeField] private Transform turret; // Объект внутри персонажа, который наводится на цель и от которого генерируется снаряд для поражения врага
    [SerializeField] private GameObject shotPrefab; // Префаб снаряда, который персонаж будет использовать

    private GameObject shot;
    private TargetPoint target; // Цель персонажа
    /*
     * 1 - default layer
     * 9 - our custom layer, which all enemies have
     * 1 << 9 - operation which bit shift by 9 elements from 0000000001 to 1000000000;
     * 1000000000 in decimal number system is equal to 512
     * ENEMY_LAYER_MASK contain value 512
     */
    private const int ENEMY_LAYER_MASK = 1 << 9;

    private void Update()
    {
        isAcquireTarger();
    }

    private void onAttack(GameObject hitObject)
    {
        if (shot == null)
        {
            shot = Instantiate(shotPrefab);
            shot.GetComponent<Shot>().damage = attackDamage;
            shot.GetComponent<Shot>().target = hitObject.transform;
            shot.transform.rotation = turret.transform.rotation;
            shot.transform.position = turret.transform.TransformPoint(Vector3.forward * 1.5f);
        }
    }

    // Find target to shoot
    private void isAcquireTarger()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, ENEMY_LAYER_MASK);
        Debug.Log(targets.Length);
        if (targets.Length > 0)
        {
            for (int i = 0; i < targets.Length; i++) {

                target = targets[i].GetComponent<TargetPoint>();
                turret.LookAt(target.position);

                Ray ray = new Ray(turret.position, turret.transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
           
                    if (hitObject.GetComponent<Enemy>())
                    {
                        onAttack(hitObject);
                    }
                }
            }
        }
    }

    public void DestroyCharacter()
    {
        ResourcesManager.Change(ResourceType.Money, costToBuy * moneyBackPercentage * 0.01f);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 pos = turret.position;
        pos.y += 0.01f;
        Gizmos.DrawWireSphere(transform.position, radiusHit);
        if(target != null)
        {
            Gizmos.color = Color.red;
            Debug.DrawLine(pos, target.position);
        }
    }
}
