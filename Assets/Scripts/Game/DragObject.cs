using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private float zCoord;
    private Vector3 offSet;
    public int damage { get; set; }

    private void Start()
    {
        DataManager.canMoveCamera = false;
    }

    private void OnDestroy()
    {
        float radiusHit = GetComponent<SphereCollider>().radius;

        Collider[] targets = Physics.OverlapSphere(transform.position, radiusHit, DataManager.ENEMY_LAYER_MASK);
        foreach (Collider target in targets)
            target.GetComponent<Enemy>().TakeDamage(damage);

        Sprite sprite = AbilitiesManager.GetAbility(Abilities.meatballsAbility).artWork;
        AbilityDisplay.onChangeArtwork(Abilities.meatballsAbility, sprite);

        DataManager.canMoveCamera = true;
    }

    private void Update()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offSet = gameObject.transform.position - GetMouseWorldPos()*Time.deltaTime;

        OnMouseDrag();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 pos = Input.mousePosition;

        pos.z = zCoord;

        return Camera.main.ScreenToWorldPoint(pos);
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = GetMouseWorldPos() - offSet* Time.deltaTime;
        newPos.y = 0.5f;
        transform.position = newPos;
    }

    private void OnMouseUp()
    {
        Vector3 position = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if(gameObject == hitObject)
                Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
