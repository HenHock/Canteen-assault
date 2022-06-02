using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public string sceneName { get; private set; } // Имя сцены, которую уровень загружает
    public TaskAbstract task_1 { get; private set; } // 1 доп. задание на уровне
    public bool task_1Finished { get; private set; }
    public TaskAbstract task_2 { get; private set; } // 2 доп. задание на уровне
    public bool task_2Finished { get; private set; }
    public int countStarsRecieved { get; private set; } // Кол-во уже полученных звезд

    public bool IsComplete;

    public void Create(LevelInfo level, bool ifPrevFinished, bool isComplete)
    {
        sceneName = level.sceneName;
        task_1 = level.task_1.GetComponent<TaskAbstract>();
        task_2 = level.task_2.GetComponent<TaskAbstract>();
        countStarsRecieved = level.countStarsRecieved;
        
        GetComponent<Button>().interactable = level.available;
        if (ifPrevFinished)
        {
            level.Unlock();
            
            GetComponent<Button>().interactable = true;
        }

        task_1Finished = level.firstTask;
        task_2Finished = level.secondTask;
        IsComplete = isComplete;
        Debug.Log("level " + sceneName);
    }

    public void onClick()
    {
        GameObject panel = UIController.onGetPanel(PanelType.detailLevelPanel);
        panel.GetComponent<LevelDisplay>().levelInfo = this;
    }
}
