using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public PanelType panelType;

    public void OnClick()
    {
        UIController.onOpenPanel(panelType);
    }
}
