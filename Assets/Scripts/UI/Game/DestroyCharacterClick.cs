using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCharacterClick : MonoBehaviour
{
    public void onClick()
    {
        if(DataManager.selectedCharacter != null)
        {
            Transform parent = DataManager.selectedCharacter.transform.parent.parent;

            if (parent.childCount > 0)
            {
                foreach (Transform item in parent)
                {
                    if (item.GetComponent<CharacterUpdatePlaceClick>() != null && item.GetComponent<CharacterSpawnPlaceClick>() != null)
                    {
                        item.GetComponent<CharacterSpawnPlaceClick>().enabled = true;
                        item.GetComponent<CharacterUpdatePlaceClick>().enabled = false;
                    }
                    else Destroy(item.gameObject);
                }
            }

            parent.GetComponent<CharacterSpawnPlaceClick>().enabled = true;
            parent.GetComponent<CharacterUpdatePlaceClick>().enabled = false;

            DataManager.selectedCharacter.GetComponent<Character>().DestroyCharacter();
            // Close update character panel
            DataManager.uIController.updateCharacterPanel.Close();
        }
    }
}
