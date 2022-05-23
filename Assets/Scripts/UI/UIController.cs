using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    /*
     * Скрипт для настройки UI главного меню.
     */

    public Button playButton;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        playButton = root.Q<Button>("button-play");

        playButton.clicked += PlayButton_Click;
    }

    public void PlayButton_Click()
    {
        Debug.Log("e");
        SceneManager.LoadScene("Main menu");
    }

}
