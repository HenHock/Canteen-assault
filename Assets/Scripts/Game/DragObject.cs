using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private float zCoord;
    private Vector3 offSet;
    [SerializeField] private GameObject dragPrefab;

    private void Start()
    {
        DataManager.canMoveCamera = false;
    }

    private void OnDestroy()
    {
        DataManager.canMoveCamera = true;
    }

    private void OnMouseDown()
    {
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offSet = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 pos = Input.mousePosition;

        pos.z = zCoord;

        return Camera.main.ScreenToWorldPoint(pos);
    }

    private void OnMouseDrag()
    {
        Vector3 newPos = GetMouseWorldPos() - offSet;
        newPos.y = 2;
        transform.position = newPos;
    }
}
