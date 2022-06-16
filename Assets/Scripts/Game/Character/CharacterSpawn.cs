using UnityEngine;
using System;
public class CharacterSpawn : MonoBehaviour
{
    public GameObject characterPrefab {get;set;}

    public static event Action<float> OnSpentMoney;

    public void onClick()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
        GameObject character = Instantiate(characterPrefab);

        if (ResourcesManager.Get(ResourceType.Money) < character.GetComponent<Character>().costToBuy)
        {
            Debug.Log("Sorry, you need more money!");
            Destroy(character);
        }
        else
        {
            character.transform.SetParent(DataManager.selectedPositionPlaceCharacterSpawn.GetChild(0).transform);
            character.GetComponent<Character>().SetRadiusAttackDisplay();
            character.transform.localPosition = new Vector3(0, 0 + character.transform.localScale.y / 2+0.21f, 0);

            ResourcesManager.Change(ResourceType.Money, -character.GetComponent<Character>().costToBuy);
            OnSpentMoney?.Invoke(character.GetComponent<Character>().costToBuy);

            if (DataManager.selectedPositionPlaceCharacterSpawn.childCount > 0)
            {
                foreach (Transform item in DataManager.selectedPositionPlaceCharacterSpawn)
                {
                    if (item.GetComponent<CharacterUpdatePlaceClick>() != null && item.GetComponent<CharacterSpawnPlaceClick>() != null)
                    {
                        item.GetComponent<CharacterSpawnPlaceClick>().enabled = false;
                        item.GetComponent<CharacterUpdatePlaceClick>().enabled = true;
                    }
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
