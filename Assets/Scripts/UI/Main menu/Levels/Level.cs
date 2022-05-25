using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public string sceneName; // ��� �����, ������� ������� ���������
    public string task_1; // 1 ���. ������� �� ������
    public string task_2; // 2 ���. ������� �� ������
    public int countStarsRecieved; // ���-�� ��� ���������� �����

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
