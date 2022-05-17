using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawn : MonoBehaviour
{
    public GameObject characterPrefab {get;set;}

    public void onClick()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        if (ResourcesManager.Get(ResourceType.Money)<characterPrefab.GetComponent<Character>().costToBuy)
        {
            Debug.Log("Sorry, you need more money!");
        }
        else
        {
            ResourcesManager.Change(ResourceType.Money, -characterPrefab.GetComponent<Character>().costToBuy);

            GameObject character = Instantiate(characterPrefab);

            character.transform.SetParent(DataManager.uIController.parentCharacter);
            character.transform.localPosition = new Vector3(DataManager.selectedPositionPlaceCharacterSpawn.localPosition.x,
                 DataManager.selectedPositionPlaceCharacterSpawn.localPosition.y + character.transform.localScale.y*3f,
                 DataManager.selectedPositionPlaceCharacterSpawn.localPosition.z);  
        }

        // Close buy character panel
        PanelController buyPanelController = this.GetComponentInParent<PanelController>();
        buyPanelController.Close();
    }
}
