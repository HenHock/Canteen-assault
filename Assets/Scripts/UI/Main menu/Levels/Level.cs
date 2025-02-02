using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField]
    private Color avaibleColor;
    
    

    [SerializeField]
    private GameObject IconSprint;
    public int levelID { get; private set; } // Номер уровня
    public string sceneName { get; private set; } // Имя сцены, которую уровень загружает
    public TaskAbstract task_1 { get; private set; } // 1 доп. задание на уровне
    public bool task_1Finished { get; private set; }
    public TaskAbstract task_2 { get; private set; } // 2 доп. задание на уровне
    public bool task_2Finished { get; private set; }
    public int countStarsRecieved { get; private set; } // Кол-во уже полученных звезд

    public bool IsComplete;

    public void Create(LevelInfo level, bool ifPrevFinished, bool isComplete, int ID)
    {
        levelID = ID;
        sceneName = level.sceneName;
        task_1 = level.task_1;
        task_2 = level.task_2;
        countStarsRecieved = level.countStarsRecieved;
   
        if (ifPrevFinished || level.available)
        {
            level.Unlock();

            //IconSprint.GetComponent<Image>().color = avaibleColor;
            GetComponent<Button>().interactable = true; 
            IconSprint.SetActive(true);
        }
        else
        {
            GetComponent<Button>().interactable = false;
            IconSprint.SetActive(false);
            //IconSprint.GetComponent<AnimationButton>()?.DeactibvateAnimatedButton();
        }

               

        task_1Finished = level.firstTask;
        task_2Finished = level.secondTask;
        IsComplete = isComplete;
    }

    public void onClick()
    {
        GameObject panel = UIController.onGetPanel(PanelType.detailLevelPanel);
        panel.GetComponent<LevelDisplay>().levelInfo = this;
    }

    
}
