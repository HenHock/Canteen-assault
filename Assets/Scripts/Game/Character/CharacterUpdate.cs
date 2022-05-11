using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUpdate : MonoBehaviour
{
    public GameObject characterPrefab { private get; set; }

    public void onClick()
    {
        UpdateCharacter();
    }

    public void UpdateCharacter()
    {
        if (ResourcesManager.Get(ResourceType.Money) < characterPrefab.GetComponent<Character>().GetCostToUpgrade())
        {
            Debug.Log("Sorry, you need more money!");
        }
        else
        {
            ResourcesManager.Change(ResourceType.Money, -characterPrefab.GetComponent<Character>().GetCostToUpgrade());

            GameObject character = Instantiate(characterPrefab);

            character.transform.localPosition = new Vector3(DataManager.selectedCharacter.transform.position.x,
                DataManager.selectedCharacter.transform.position.y, DataManager.selectedCharacter.transform.position.z);

            Destroy(DataManager.selectedCharacter);
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
    }
}
