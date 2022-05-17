using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
    public int costToBuy; // ��������� ������� ���������
    public int costToUpgrade; // ��������� ��������� ������ ���������
    public int attackDamage; // �������� ����� ���������
    [Range(1,100)] public float moneyBackPercentage; // ������� �����, �� �������, ������� ����� ��������� ������ ��� �������� ���������
    public GameObject nextLevelPrefab; // ������ �� ��������� ������� ���������.

    [SerializeField, Range(1.5f, 10f)] public float radiusHit = 1.5f; // ������, � ������� �������� ������ ��������.
    [SerializeField, Range (1f, 10f)] public float attackSpeed = 2f; // �������� ����� ���������
    [SerializeField] private Transform turret; // ������ ������ ���������, ������� ��������� �� ���� � �� �������� ������������ ������ ��� ��������� �����
    [SerializeField] private GameObject shotPrefab; // ������ �������, ������� �������� ����� ������������

    private GameObject shot;
    private TargetPoint target; // ���� ���������
    private float nextShoot = 0;

    private void Update()
    {
        if (isAcquireTarger())
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

            if (Time.time > nextShoot)
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

    private bool cooldawnAttack(float time)
    {
        if (time - Time.time > attackSpeed)
            return true;

        return false;
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
