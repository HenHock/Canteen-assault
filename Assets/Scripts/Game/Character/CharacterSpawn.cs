using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField] private float price;
    public GameObject characterPrefab {get;set;}

    public void onClick()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        GameObject Map = GameObject.Find("Map");

        if (CurrencyManager.CurrentAmount < price)
        {
            Debug.Log("Sorry, you need more money!");
        }
        else
        {
            CurrencyManager.CurrentAmount -= price;

            GameObject character = Instantiate(characterPrefab);

            if (Map != null)
                character.transform.SetParent(Map.transform);

            character.transform.localPosition = new Vector3(DataManager.selectedPositionPlaceCharacterSpawn.x, 
                DataManager.selectedPositionPlaceCharacterSpawn.y + character.transform.localScale.y, 
                DataManager.selectedPositionPlaceCharacterSpawn.z);
        }

        // Close buy character panel
        PanelController buyPanelController = this.GetComponentInParent<PanelController>();
        buyPanelController.Close();
    }
}
