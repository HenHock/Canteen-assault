using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
    public int damage;
    public int costToBuy;
    public int costToUpgrade;
    public float radiusHit;
    public LayerMask layerMask;

    public GameObject hitObject;

    [SerializeField] private GameObject shotPrefab;
    private GameObject shot;
    private RaycastHit hit;

    public void onAttack()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.SphereCast(ray, radiusHit, out hit, 5))
        {
            hitObject = hit.transform.gameObject;
            
            if (hitObject.GetComponent<EnemyTemplate>())
            {
                if (shot == null)
                {
                    shot = Instantiate(shotPrefab);
                    shot.GetComponent<ShotTemplate>().damage = damage;
                    shot.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    shot.transform.rotation = transform.rotation;
                }
            }
        }
    }

    private void Update()
    {
        onAttack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Debug.DrawLine(transform.position, transform.position + transform.forward * hit.distance);
        Gizmos.DrawSphere(transform.position + transform.forward * hit.distance, radiusHit);
    }
}
