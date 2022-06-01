using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelInfo", menuName = "LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public GameObject task_1;
    public GameObject task_2;
    public int countStarsRecieved;
    public string sceneName;


    [SerializeField] private bool defaultAvailable;
    
    public bool available;
    public bool firstTask;
    public bool secondTask;

    public void CompleteTask(int number)
    {
        if (number == 1)
        {
            firstTask = true;
            ES3.Save($"{sceneName} Task 1", firstTask);
        }
        else
        {
            secondTask = true;
            ES3.Save($"{sceneName} Task 2", secondTask);
        }
    }

    public void Unlock()
    {
        available = true;
        ES3.Save(sceneName, available);
    }

    private void Awake()
    {
        available = ES3.Load(sceneName, defaultAvailable);
        firstTask = ES3.Load($"{sceneName} Task 1", false);
        secondTask = ES3.Load($"{sceneName} Task 2", false);
        
        Debug.Log($"{sceneName}: {available} ... {defaultAvailable}");
    }
}
