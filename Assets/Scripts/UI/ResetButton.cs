using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private ResourceItemSO health;
    [SerializeField] private ResourceItemSO money;

    public void onClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());

        ResourcesManager.Change(health, -ResourcesManager.Get(health));
        ResourcesManager.Change(money, -ResourcesManager.Get(money));
        Time.timeScale = 1;
    }
}
