using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string sceneName; // »м€ сцены, которую уровень загружает
    public string task_1; // 1 доп. задание на уровне
    public string task_2; // 2 доп. задание на уровне
    public int countStarsRecieved; //  ол-во уже полученных звезд

    public void Create(string sceneName, string task_1, string task_2, int countStarsRecieved)
    {
        this.sceneName = sceneName;
        this.task_1 = task_1;
        this.task_2 = task_2;
        this.countStarsRecieved = countStarsRecieved;
    }

    public void onClick()
    {
        GameObject panel = UIController.onGetPanel(PanelType.detailLevelPanel);
        panel.GetComponent<LevelDisplay>().levelInfo = this;
    }
}
