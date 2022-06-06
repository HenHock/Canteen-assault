using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public PanelController buyCharacterPanelController;
    public PanelController endGamePanel;
    public PanelController updateCharacterPanel;
    public PanelController pausePanel;

    private void Awake()
    {
        buyCharacterPanelController.Close();
        endGamePanel.Close();
        updateCharacterPanel.Close();
        pausePanel.Close();
    }
}
