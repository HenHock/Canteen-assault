using UnityEngine;
using System;
public class CharacterUpdate : MonoBehaviour
{
    public GameObject characterPrefab { private get; set; }
    public static event Action<float> OnSpentMoneyUpdate;

    public void onClick()
    {
        UpdateCharacter();
    }

    public void UpdateCharacter()
    {
        GameObject character = Instantiate(characterPrefab);

        if (ResourcesManager.Get(ResourceType.Money) < character.GetComponent<Character>().costToBuy)
        {
            Debug.Log("Sorry, you need more money!");
            Destroy(character);
        }
        else
        {
            ResourcesManager.Change(ResourceType.Money, -character.GetComponent<Character>().costToBuy);
            OnSpentMoneyUpdate?.Invoke(character.GetComponent<Character>().costToBuy);

            character.transform.SetParent(DataManager.selectedCharacter.transform.parent);
            character.GetComponent<Character>().SetRadiusAttackDisplay();
            character.transform.localPosition = new Vector3(DataManager.selectedCharacter.transform.localPosition.x,
                DataManager.selectedCharacter.transform.localPosition.y, DataManager.selectedCharacter.transform.localPosition.z);

            Destroy(DataManager.selectedCharacter);
        }


        if (DataManager.uIController != null)
        {
            // Destroy all UpdateCharacterItem
            foreach (Transform child in DataManager.uIController.updateCharacterPanel.transform)
                if (child.GetComponentInChildren<CharacterUpdate>() != null)
                    Destroy(child.GetChild(0).gameObject);

            // Close update character panel
            DataManager.uIController.updateCharacterPanel.Close();
        }
    }
}
