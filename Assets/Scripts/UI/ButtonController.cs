using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public PanelType panelType;

    public void OnOpenPanel()
    {
        UIController.onOpenPanel(panelType);
    }

    public void OnClosePanel()
    {
        UIController.onClosePanel(panelType);
    }
}
