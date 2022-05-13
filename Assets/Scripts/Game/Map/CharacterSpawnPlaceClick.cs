using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterSpawnPlaceClick : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();

    public void OnMouseUpAsButton()
    {
        if (DataManager.uIController != null)
        {
            DataManager.uIController.buyCharacterPanelController.Open();
            DataManager.selectedPositionPlaceCharacterSpawn = this.transform.localPosition;
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
