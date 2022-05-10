using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUpdate : MonoBehaviour
{
    [SerializeField] private float price;
    [SerializeField] private ResourceItemSO resource;
    //[SerializeField] private GameObject Map;
    public GameObject characterPrefab { private get; set; }

    public void onClick()
    {
        UpdateCharacter();
    }

    public void UpdateCharacter()
    {
        GameObject Map = GameObject.Find("Map");

        if (ResourcesManager.Get(resource) < price)
        {
            Debug.Log("Sorry, you need more money!");
        }
        else
        {
            ResourcesManager.Change(resource, -price);

            GameObject character = Instantiate(characterPrefab);

            if (Map != null)
                character.transform.SetParent(Map.transform);

            character.transform.localPosition = new Vector3(DataManager.selectedCharacter.transform.position.x,
                DataManager.selectedCharacter.transform.position.y, DataManager.selectedCharacter.transform.position.z);
        }


        if (DataManager.uIController != null)
        {
            // Destroy all UpdateCharacterItem
            foreach (Transform child in DataManager.uIController.updateCharacterPanel.transform)
                if (child.GetComponentInChildren<CharacterUpdate>() != null)
                    Destroy(child.gameObject);

            // Close update character panel
            DataManager.uIController.updateCharacterPanel.Close();
        }

        Destroy(DataManager.selectedCharacter);
    }
}
