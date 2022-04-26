using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterSpawnPlaceClick : MonoBehaviour
{
    public UnityEvent unityEvent = new UnityEvent();

    public void onClick()
    {
        UIController uIController = GameObject.Find("UIController").GetComponent<UIController>();
        if (uIController != null)
            uIController.buyCharacterPanelController.Open();
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                unityEvent.Invoke();
            }
        }
    }
}
