using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickPlayLevelButton : MonoBehaviour
{
    public void onClick()
    {
        if (GlobalApplicationData.IsFirstLaunch)
            SceneManager.LoadScene("Level 1");
        else
        {
            for(int i = 1;i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                if (!ES3.Load($"{sceneName} Finished", false))
                {
                    SceneManager.LoadScene(i);
                    break;
                }
            }
        }
    }
}
