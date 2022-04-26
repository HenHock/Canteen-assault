using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject characterPrefab;

    public void onClick()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        GameObject Map = GameObject.Find("Map");

        if (DataManager.uIController != null)
            if (DataManager.uIController.changeMoney(-Convert.ToInt32(GetComponentInChildren<Text>().text)))
            {
                GameObject character = Instantiate(characterPrefab);

                if (Map != null)
                    character.transform.SetParent(Map.transform);

                character.transform.localPosition = DataManager.selectedPositionPlaceCharacterSpawn;
            }

        // Close buy character panel
        PanelController buyPanelController = this.GetComponentInParent<PanelController>();
        buyPanelController.Close();
    }
}
