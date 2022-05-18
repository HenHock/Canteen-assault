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

            character.transform.SetParent(DataManager.selectedPositionPlaceCharacterSpawn.GetChild(0).transform);
            character.transform.localPosition = new Vector3(0,0 + character.transform.localScale.y/2,0);

            if(DataManager.selectedPositionPlaceCharacterSpawn.childCount > 0)
            {
                foreach (Transform item in DataManager.selectedPositionPlaceCharacterSpawn)
                {
                    item.GetComponent<CharacterSpawnPlaceClick>().enabled = false;
                    item.GetComponent<CharacterUpdatePlaceClick>().enabled = true;
                }
            }

            DataManager.selectedPositionPlaceCharacterSpawn.GetComponent<CharacterSpawnPlaceClick>().enabled = false;
            DataManager.selectedPositionPlaceCharacterSpawn.GetComponent<CharacterUpdatePlaceClick>().enabled = true;
        }

        // Close buy character panel
        PanelController buyPanelController = this.GetComponentInParent<PanelController>();
        buyPanelController.Close();
    }
}
