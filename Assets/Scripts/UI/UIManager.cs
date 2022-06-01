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
    public PanelController pausePanel;
    public GameObject sceneIgnoring;

    [SerializeField] private GameObject titleEndGameText;
    [SerializeField] private GameObject Stars;

    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject resetButton;

    [SerializeField] private GameObject firstTask;
    [SerializeField] private GameObject secondTask;
    [SerializeField] private GameObject Tasks;
    [SerializeField] private Sprite completeTask;
    [SerializeField] private Sprite unCompleteTask;

    private void Awake()
    {
        DataManager.uIController = this;
        sceneIgnoring.SetActive(false);

        nextLevelButton.SetActive(false);
        buyCharacterPanelController.Close();
        endGamePanel.Close();
        updateCharacterPanel.Close();
        pausePanel.Close();
    }

    public void Win()
    {
        endGamePanel.Open();
        titleEndGameText.GetComponent<TextMeshProUGUI>().text = "You win!";

        TaskAbstract[] tasksDescription = Tasks.GetComponentsInChildren<TaskAbstract>();
        firstTask.GetComponentInChildren<TextMeshProUGUI>().text = tasksDescription[0].GetTextTask();
        secondTask.GetComponentInChildren<TextMeshProUGUI>().text = tasksDescription[1].GetTextTask();

        int starCount = 1;
        if (tasksDescription[0].CheckIfComplete())
        {
            firstTask.GetComponentInChildren<Image>().sprite = completeTask;
            starCount++;
        }
        if (tasksDescription[1].CheckIfComplete())
        {
            secondTask.GetComponentInChildren<Image>().sprite = completeTask;
            starCount++;
        }
        ResourcesManager.Change(ResourceType.Star, starCount); // Добавляем звезды за победу
        Stars.GetComponent<Image>().sprite = StarsIcon.GetIcon(starCount); // Устанавливаем новую иконку в зависимотси от полученных звезд
        Stars.GetComponentInChildren<TextMeshProUGUI>().text = starCount.ToString();

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
