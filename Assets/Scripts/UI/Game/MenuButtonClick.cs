using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonClick : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene(0); // Загружаем сцену MainMenu
    }
}
