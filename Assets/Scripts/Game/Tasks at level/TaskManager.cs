using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField]
    private LevelInfo levelInfo;

    private void Awake()
    {
        GameObject firstTask = Instantiate(levelInfo.task_1);
        firstTask.transform.SetParent(transform);

        GameObject secondTask = Instantiate(levelInfo.task_2);
        secondTask.transform.SetParent(transform);
    }

    public LevelInfo getLevelInfo()
    {
        return levelInfo;
    }
}
