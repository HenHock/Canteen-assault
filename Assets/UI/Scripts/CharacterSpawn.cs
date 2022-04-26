using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    [SerializeField] private static GameObject characterPrefab;

    public void onClick()
    {
        SpawnCharacter(0);
    }

    private void SpawnCharacter(int placeID)
    {
        GameObject Map = GameObject.Find("Map");
        // -1 10 1
        GameObject character = Instantiate(characterPrefab);

        if(Map != null)
            character.transform.SetParent(Map.transform);
        character.transform.localPosition = new Vector3(-1, 10, 1);

        // Close buy panel
        PanelController buyPanelController = this.GetComponentInParent<PanelController>();
        buyPanelController.Close();
    }
}
