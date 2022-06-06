using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanelController : PanelController
{
    [SerializeField] private GameObject firstTask;
    [SerializeField] private GameObject secondTask;
    [SerializeField] private Sprite completeTask;
    [SerializeField] private Sprite unCompleteTask;
    [SerializeField] private TextMeshProUGUI levelIDDisplay;

    private void OnEnable()
    {
        LevelInfo levelInfo = DataManager.levelInfo;

        levelIDDisplay.text = levelInfo.sceneName;

        if (SceneManager.GetActiveScene().name.Equals("Main menu"))
            UIController.onBlurAction(true);
        else UIManager.OnBlurAction(true);

        Time.timeScale = 0;

        firstTask.GetComponentInChildren<TextMeshProUGUI>().text = levelInfo.task_1.GetTextTask();
        secondTask.GetComponentInChildren<TextMeshProUGUI>().text = levelInfo.task_2.GetTextTask();

        if (levelInfo.task_1.CheckIfComplete())
        {
            firstTask.GetComponentInChildren<Image>().sprite = completeTask;
        }else firstTask.GetComponentInChildren<Image>().sprite = unCompleteTask;
        if (levelInfo.task_2.CheckIfComplete())
        {
            secondTask.GetComponentInChildren<Image>().sprite = completeTask;
        }else secondTask.GetComponentInChildren<Image>().sprite = unCompleteTask;
    }

    private void OnDisable()
    {
        if (SceneManager.GetActiveScene().name.Equals("Main menu"))
            UIController.onBlurAction(false);
        else UIManager.OnBlurAction(false);

        Time.timeScale = 1;
    }
}
