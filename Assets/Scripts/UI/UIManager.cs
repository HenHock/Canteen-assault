using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

/*
 * Скрипт для настройки UI в уровнях
 */

public class UIManager : MonoBehaviour
{
    public PanelController buyCharacterPanelController;
    public PanelController endGamePanel;
    public PanelController updateCharacterPanel;
    public GameObject sceneIgnoring;

    [SerializeField] private GameObject titleEndGameText;
    [SerializeField] private GameObject statisticsEndGameText;
    [SerializeField] private GameObject Stars;

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
        titleEndGameText.GetComponent<TextMeshProUGUI>().text = "You win!";
        ResourcesManager.Change(ResourceType.Star, 1); // Добавляем одну звезду за победу
        Stars.GetComponent<Image>().sprite = StarsIcon.GetIcon(ResourcesManager.Get(ResourceType.Star)); // Устанавливаем новую иконку в зависимотси от полученных звезд
        Stars.GetComponentInChildren<TextMeshProUGUI>().text = ResourcesManager.Get(ResourceType.Star).ToString();
        //statisticsEndGameText.GetComponent<TextMeshProUGUI>().text = $"You earned {ResourcesManager.Get(ResourceType.Star)} star!";

        nextLevelButton.SetActive(true);

        if(ResourcesManager.Get(ResourceType.Star) == 3)
            resetButton.SetActive(false);
    }

    public void Lose()
    {
        endGamePanel.Open();
        titleEndGameText.GetComponent<TextMeshProUGUI>().text = "You lose";
        //statisticsEndGameText.GetComponent<TextMeshProUGUI>().text = "You can try again!";

        nextLevelButton.SetActive(false);
        resetButton.SetActive(true);
        resetButton.transform.Translate(Vector3.right*170/2); // Устанавливаем кнопку по середине
    }

    /// <summary>
    /// Проверяет если курсор находится на UI объекте
    /// </summary>
    /// <returns>true or false</returns>
    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

}
