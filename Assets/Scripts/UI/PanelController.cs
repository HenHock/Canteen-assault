using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public void Close()
    {
        if (DataManager.isPanel)
        {
            gameObject.SetActive(false);
            DataManager.isPanel = false;
        }
    }

    public void Open()
    {
        if (!DataManager.isPanel)
        {
            gameObject.SetActive(true);
            DataManager.isPanel = true;
        }
    }
}
