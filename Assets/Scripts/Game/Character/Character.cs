using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
    public int costToBuy; // Ñòîèìîñòü ïîêóïêè ïåðñîíàæà
    public int costToUpgrade; // Ñòîèìîñòü ïîâûøåíèÿ óðîâíÿ ïåðñîíàæà
    public int attackDamage; // Çíà÷åíèå óðîíà ïåðñîíàæà
    [Range(1,100)] public float moneyBackPercentage; // Ïðîöåíò äåíåã, îò ïîêóïêè, êîòîðûé áóäåò âîçâðàùåí èãðîêó ïðè óäàëåíèå ïåðñîíàæà
    public GameObject nextLevelPrefab; // Ïðåôàá íà ñëåäóþùèé óðîâåíü ïåðñîíàæà.

    [SerializeField, Range(1.5f, 10f)] public float radiusHit = 1.5f; // Ðàäèóñ, â êîòîðîì ïåðñîíàæ ñìîæåò ñòðåëÿòü.
    [SerializeField, Range (1f, 10f)] public float attackSpeed = 2f; // Ñêîðîñòü àòàêè ïåðñîíàæà
    [SerializeField] private Transform turret; // Îáúåêò âíóòðè ïåðñîíàæà, êîòîðûé íàâîäèòñÿ íà öåëü è îò êîòîðîãî ãåíåðèðóåòñÿ ñíàðÿä äëÿ ïîðàæåíèÿ âðàãà
    [SerializeField] private GameObject shotPrefab; // Ïðåôàá ñíàðÿäà, êîòîðûé ïåðñîíàæ áóäåò èñïîëüçîâàòü

    private GameObject shot;
    [SerializeField] private TargetPoint target; // Öåëü ïåðñîíàæà
    private float nextShoot = 0;

    private void Update()
    {
        if (isAcquireTarger() || isTargetTrucked())
            onAttack();
    }

    private void onAttack()
    {
        if(target != null)
            turret.LookAt(target.position);

        Ray ray = new Ray(turret.position, turret.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            
            if (Time.time > nextShoot && hitObject.GetComponent<Enemy>() != null)
            {
                shot = Instantiate(shotPrefab);
                shot.GetComponent<Shot>().damage = attackDamage;
                shot.GetComponent<Shot>().target = hitObject.transform;
                shot.transform.rotation = turret.transform.rotation;
                shot.transform.position = turret.transform.TransformPoint(Vector3.forward * 1.5f);
                nextShoot = Time.time + (1000 / attackSpeed) / 1000;
            }
        }
    }

    // Find target to shoot
    private bool isAcquireTarger()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, DataManager.ENEMY_LAYER_MASK);

        if (targets.Length > 0)
        {
            target = targets[0].GetComponent<TargetPoint>();
            return true;
        }
        
        target = null;
        return false;
    }

    private bool isTargetTrucked()
    {
        if (target == null)
            return false;
        else
        {
            Vector3 myPos = transform.localPosition;
            Vector3 targetPos = target.position;
            if (Vector3.Distance(myPos, targetPos) > radiusHit + target.colliderSize*target.enemy.scale) { 
                target = null;
                return false;
            }
        }

        return true;
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
