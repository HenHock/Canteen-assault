using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelInfo", menuName = "LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public TaskAbstract task_1;
    public TaskAbstract task_2;
    public int countStarsRecieved { get; private set; } = 0;
    public string sceneName;


    [SerializeField] private bool defaultAvailable;

    public bool finished;
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
        //Debug.Log("here at level "+sceneName);
        available = true;
        //Debug.Log(available);
        ES3.Save(sceneName, available);
    }

    private void Awake()
    {
        available = ES3.Load(sceneName, defaultAvailable);
        firstTask = ES3.Load($"{sceneName} Task 1", false);
        secondTask = ES3.Load($"{sceneName} Task 2", false);
        finished = ES3.Load($"{sceneName} Finished", false);

        if(firstTask)
            countStarsRecieved++;
        if(secondTask)
            countStarsRecieved++;
        if (finished)
            countStarsRecieved++;
        
        
        Debug.Log($"{sceneName}: {available} ... {defaultAvailable}");
    }

    public void UpdateData()
    {
        Debug.Log(sceneName);
        firstTask = ES3.Load($"{sceneName} Task 1", false);
        secondTask = ES3.Load($"{sceneName} Task 2", false);
        finished = ES3.Load($"{sceneName} Finished", false);

        if (firstTask)
            countStarsRecieved++;
        if (secondTask)
            countStarsRecieved++;
        if (finished)
            countStarsRecieved++;
    }
    
    public void LevelFinish()
    {
        finished = true;
        ES3.Save($"{sceneName} Finished", finished);
    }
}
