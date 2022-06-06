using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private PanelController previouslyPanel;

    public void Close()
    {
        if(DataManager.uIController != null)
            DataManager.uIController.sceneIgnoring.SetActive(false);

        DataManager.activePanel = null;

        gameObject.SetActive(false);
    }

    public void Open()
    {
        if (DataManager.activePanel != null)
            DataManager.activePanel.GetComponent<PanelController>().Close();

        DataManager.activePanel = gameObject;

        if (DataManager.uIController != null)
            DataManager.uIController.sceneIgnoring.SetActive(true);

        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        if (UIController.onBlurAction != null)
            UIController.onBlurAction(true);
        else UIManager.OnBlurAction(true);
    }

    private void OnDisable()
    {
        if (UIController.onBlurAction != null)
            UIController.onBlurAction(false);
        else UIManager.OnBlurAction(false);
    }
}
