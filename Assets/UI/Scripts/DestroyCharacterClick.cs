using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCharacterClick : MonoBehaviour
{
    public void onClick()
    {
        if(DataManager.selectedCharacter != null)
        {
            Destroy(DataManager.selectedCharacter);

            // Close update character panel
            DataManager.uIController.updateCharacterPanel.Close();
        }
    }
}
