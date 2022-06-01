using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    public string sceneName { get; private set; } // ��� �����, ������� ������� ���������
    public TaskAbstract task_1 { get; private set; } // 1 ���. ������� �� ������
    public TaskAbstract task_2 { get; private set; } // 2 ���. ������� �� ������
    public int countStarsRecieved { get; private set; } // ���-�� ��� ���������� �����

    public void Create(LevelInfo level)
    {
        sceneName = level.sceneName;
        task_1 = level.task_1.GetComponent<TaskAbstract>();
        task_2 = level.task_2.GetComponent<TaskAbstract>();
        countStarsRecieved = level.countStarsRecieved;
    }

    public void onClick()
    {
        GameObject panel = UIController.onGetPanel(PanelType.detailLevelPanel);
        panel.GetComponent<LevelDisplay>().levelInfo = this;
    }
}
