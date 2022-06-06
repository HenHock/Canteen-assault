using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public static GameObject blur;
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
        if (UIManager.OnBlurAction != null)
            UIManager.OnBlurAction(true);
        else UIController.onBlurAction(true);
    }

    private void OnDisable()
    {
        if (UIManager.OnBlurAction != null)
            UIManager.OnBlurAction(false);
        else UIController.onBlurAction(false);
    }
}
