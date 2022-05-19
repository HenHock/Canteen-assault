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
        if (ResourcesManager.Get(ResourceType.Money) < characterPrefab.GetComponent<Character>().costToBuy)
        {
            Debug.Log("Sorry, you need more money!");
        }
        else
        {
            ResourcesManager.Change(ResourceType.Money, -characterPrefab.GetComponent<Character>().costToBuy);

            GameObject character = Instantiate(characterPrefab);

            character.transform.SetParent(DataManager.selectedCharacter.transform.parent);
            character.transform.localPosition = new Vector3(DataManager.selectedCharacter.transform.localPosition.x,
                DataManager.selectedCharacter.transform.localPosition.y, DataManager.selectedCharacter.transform.localPosition.z);

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
