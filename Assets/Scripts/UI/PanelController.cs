using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public void Close()
    {

        DataManager.uIController.sceneIgnoring.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Open()
    {
        DataManager.uIController.sceneIgnoring.SetActive(true);
        gameObject.SetActive(true);
    }
}
