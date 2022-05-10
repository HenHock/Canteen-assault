using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int index;

    private void Awake()
    {
        index = SceneManager.GetActiveScene().buildIndex;
    }

    public void NextLevel()
    {
        string nextSceneName = SceneManager.GetSceneByBuildIndex(index + 1).name;
        Debug.Log(index);
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(index + 1).name);
    }

    public void PreviouslyLevel()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(index - 1).name);
    }
}
