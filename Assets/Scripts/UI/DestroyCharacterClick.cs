using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCharacterClick : MonoBehaviour
{
    public void onClick()
    {
        if(DataManager.selectedCharacter != null)
        {
            DataManager.selectedCharacter.GetComponent<Character>().DestroyCharacter();

            // Close update character panel
            DataManager.uIController.updateCharacterPanel.Close();
        }
    }
}
