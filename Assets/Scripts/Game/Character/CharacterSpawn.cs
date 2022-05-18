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
            //character.transform.localPosition = new Vector3(DataManager.selectedPositionPlaceCharacterSpawn.localPosition.x,
            //  DataManager.selectedPositionPlaceCharacterSpawn.localPosition.y + character.transform.localScale.y * 3f,
            // DataManager.selectedPositionPlaceCharacterSpawn.localPosition.z);
            character.transform.localPosition = Vector3.zero;

            if(DataManager.selectedPositionPlaceCharacterSpawn.childCount > 0)
            {
                foreach (Transform item in DataManager.selectedPositionPlaceCharacterSpawn)
                {
                    item.GetComponent<CharacterSpawnPlaceClick>().gameObject.SetActive(false);
                    item.GetComponent<CharacterUpdatePlaceClick>().gameObject.SetActive(true);
                }
            }

            DataManager.selectedPositionPlaceCharacterSpawn.GetComponent<CharacterSpawnPlaceClick>().gameObject.SetActive(false);
            DataManager.selectedPositionPlaceCharacterSpawn.GetComponent<CharacterUpdatePlaceClick>().gameObject.SetActive(true);
        }

        // Close buy character panel
        PanelController buyPanelController = this.GetComponentInParent<PanelController>();
        buyPanelController.Close();
    }
}
