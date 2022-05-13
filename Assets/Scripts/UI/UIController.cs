using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public PanelController buyCharacterPanelController;
    public PanelController endGamePanel;
    public PanelController updateCharacterPanel;

    public GameObject TitleEndGameText;
    public GameObject StatisticsEndGameText;

    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject previouslyLevelButton;

    private void Awake()
    {
        DataManager.uIController = this;

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            nextLevelButton.SetActive(true);
            previouslyLevelButton.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            nextLevelButton.SetActive(false);
            previouslyLevelButton.SetActive(true);
        }

        buyCharacterPanelController.Close();
        endGamePanel.Close();
        updateCharacterPanel.Close();
    }

}
