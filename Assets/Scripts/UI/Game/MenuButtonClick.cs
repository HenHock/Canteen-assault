using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonClick : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Main menu"); // Загружаем сцену MainMenu
        ResourcesManager.Reset(ResourceType.Money);
        ResourcesManager.Reset(ResourceType.Life);
        ResourcesManager.Reset(ResourceType.EnemyCount);
        ResourcesManager.Reset(ResourceType.NumberWave);
    }
}
