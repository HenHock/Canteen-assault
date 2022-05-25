using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesController : MonoBehaviour
{
    public void NextLevel()
    {
        DataManager.currentLevel++;
        if (DataManager.currentLevel >= LevelManager.returnNumberOfLevels())
        { 
            DataManager.currentLevel = 0;
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        ResourcesManager.Reset(ResourceType.Life);
        ResourcesManager.Reset(ResourceType.Money);
        Time.timeScale = 1;

    }

    public void PreviouslyLevel()
    {
        ResourcesManager.Reset(ResourceType.Life);
        ResourcesManager.Reset(ResourceType.Money);
        ResourcesManager.Reset(ResourceType.EnemyCount);
        ResourcesManager.Reset(ResourceType.NumberWave);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }
}
