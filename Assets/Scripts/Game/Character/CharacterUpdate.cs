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
        GameObject Map = GameObject.Find("Map");

        if (DataManager.uIController != null)
            if (DataManager.uIController.changeMoney(-Convert.ToInt32(GetComponentInChildren<Text>().text)))
            {
                GameObject character = Instantiate(characterPrefab);

                if (Map != null)
                    character.transform.SetParent(Map.transform);

                character.transform.localPosition = new Vector3(DataManager.selectedCharacter.transform.position.x, DataManager.selectedCharacter.transform.position.y, DataManager.selectedCharacter.transform.position.z);
            }
            else
            {
                Debug.Log("Sorry, you need more money!");
            }

        
        if (DataManager.uIController != null)
        {
            // Destroy all UpdateCharacterItems
            foreach (Transform child in DataManager.uIController.updateCharacterPanel.transform)
                if (child.GetComponentInChildren<CharacterUpdate>() != null)
                    Destroy(child.gameObject);

            // Close update character panel
            DataManager.uIController.updateCharacterPanel.Close();
        }

        Destroy(DataManager.selectedCharacter);
    }
}
