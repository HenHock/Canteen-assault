using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public void Close()
    {
        gameObject.SetActive(false);
        DataManager.isPanel = false;
    }

    public void Open()
    {
        gameObject.SetActive(true);
        DataManager.isPanel = true;
    }
}
