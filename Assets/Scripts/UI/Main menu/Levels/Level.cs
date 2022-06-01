using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string sceneName { get; private set; } // ��� �����, ������� ������� ���������
    public string task_1 { get; private set; } // 1 ���. ������� �� ������
    public string task_2 { get; private set; } // 2 ���. ������� �� ������
    public int countStarsRecieved { get; private set; } // ���-�� ��� ���������� �����

    public void Create(LevelInfo level)
    {
        sceneName = level.sceneName;
        task_1 = level.task_1.GetComponent<TaskAbstract>().GetTextTask();
        task_2 = level.task_2.GetComponent<TaskAbstract>().GetTextTask();
        countStarsRecieved = level.countStarsRecieved;
    }

    public void onClick()
    {
        GameObject panel = UIController.onGetPanel(PanelType.detailLevelPanel);
        panel.GetComponent<LevelDisplay>().levelInfo = this;
    }
}
