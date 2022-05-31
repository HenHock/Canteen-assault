using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonClick : MonoBehaviour
{
    public void onClick()
    {
        DataManager.uIController.pausePanel.Open();
    }
}
