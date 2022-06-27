using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterUpdatePlaceClick : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent = new UnityEvent();

    void Update()
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

    public void onClick()
    {
        if (DataManager.uIController != null && !UIManager.IsPointerOverUIObject())
        {
            if (transform.childCount > 0)
                DataManager.selectedCharacter = GetLastChild(gameObject);
            else DataManager.selectedCharacter = gameObject;

            DataManager.uIController.updateCharacterPanel.Open();
        }
    }


    private GameObject GetLastChild(GameObject parent)
    {
        if (parent.name.Equals("chair"))
            return parent.transform.GetChild(0).gameObject;
        else
        {
            Transform child = parent.transform.Find("chair");
            if (child != null)
                return child.GetChild(0).gameObject;
        }
        
        return null;
    }
}
