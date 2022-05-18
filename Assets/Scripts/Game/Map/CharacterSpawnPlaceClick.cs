using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterSpawnPlaceClick : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();

    public void onClick()
    {
        if (DataManager.uIController != null && !UIManager.IsPointerOverUIObject())
        {
            DataManager.uIController.buyCharacterPanelController.Open();

            if (transform.parent.GetComponent<CharacterSpawnPlaceClick>() != null)
                DataManager.selectedPositionPlaceCharacterSpawn = transform.parent;
            else DataManager.selectedPositionPlaceCharacterSpawn = transform;
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit) 
                && hit.collider.gameObject == gameObject)
            {
                unityEvent.Invoke();
            }
        }
    }
}
