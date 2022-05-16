using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public PanelController buyCharacterPanelController;
    public PanelController endGamePanel;
    public PanelController updateCharacterPanel;
    public GameObject sceneIgnoring;

    [SerializeField] private GameObject titleEndGameText;
    [SerializeField] private GameObject statisticsEndGameText;

    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject resetButton;

    private void Awake()
    {
        DataManager.uIController = this;
        sceneIgnoring.SetActive(false);

        nextLevelButton.SetActive(false);
        buyCharacterPanelController.Close();
        endGamePanel.Close();
        updateCharacterPanel.Close();
    }

    public void Win()
    {
        endGamePanel.Open();
        titleEndGameText.GetComponent<Text>().text = "You win!";
        statisticsEndGameText.GetComponent<Text>().text = $"You earned {ResourcesManager.Get(ResourceType.Star)} star!";

        nextLevelButton.SetActive(true);
        resetButton.SetActive(false);
    }

    public void Lose()
    {
        endGamePanel.Open();
        titleEndGameText.GetComponent<Text>().text = "You lose :(";
        statisticsEndGameText.GetComponent<Text>().text = "You can try again!";

        nextLevelButton.SetActive(false);
        resetButton.SetActive(true);
    }

}
