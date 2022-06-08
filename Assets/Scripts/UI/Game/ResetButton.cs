using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{

    public void onClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());

        ResourcesManager.Reset(ResourceType.Life);
        ResourcesManager.Reset(ResourceType.Money);
        ResourcesManager.Reset(ResourceType.EnemyCount);
        ResourcesManager.Reset(ResourceType.NumberWave);

       
        //ResourcesManager.Reset(ResourceType.Star);
    }
}
