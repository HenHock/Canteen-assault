using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    public PanelController buyCharacterPanelController;
    public PanelController endGamePanel;
    public PanelController updateCharacterPanel;



    private void Start()
    {

        buyCharacterPanelController.Close();
        endGamePanel.Close();
        updateCharacterPanel.Close();
    }

}
