using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PausePanelController : PanelController
{
    [SerializeField] private GameObject firstTask;
    [SerializeField] private GameObject secondTask;
    [SerializeField] private GameObject Tasks;
    [SerializeField] private Sprite completeTask;
    [SerializeField] private Sprite unCompleteTask;

    private void OnEnable()
    {
        Time.timeScale = 0;

        TaskAbstract[] tasksDescription = Tasks.GetComponentsInChildren<TaskAbstract>();
        firstTask.GetComponentInChildren<TextMeshProUGUI>().text = tasksDescription[0].GetTextTask();
        secondTask.GetComponentInChildren<TextMeshProUGUI>().text = tasksDescription[1].GetTextTask();

        if (tasksDescription[0].CheckIfComplete())
        {
            firstTask.GetComponentInChildren<Image>().sprite = completeTask;
        }else firstTask.GetComponentInChildren<Image>().sprite = unCompleteTask;
        if (tasksDescription[1].CheckIfComplete())
        {
            secondTask.GetComponentInChildren<Image>().sprite = completeTask;
        }else secondTask.GetComponentInChildren<Image>().sprite = unCompleteTask;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
