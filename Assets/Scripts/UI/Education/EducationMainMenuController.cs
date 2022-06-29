using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EducationMainMenuController : MonoBehaviour
{
    /*
     * Script for controll left and right dialog panel on the MainMenu scene
     */

    [SerializeField] private Scenario scenario;
    [SerializeField] private DialogPanel leftDialogPanel;
    [SerializeField] private DialogPanel rightDialogPanel;

    private void Start()
    {
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        if (!scenario.isEmpty())
        {
            Phrases phrase = scenario.GetNextPhrases();

            bool flag = leftDialogPanel.gameObject.activeInHierarchy;
            leftDialogPanel.gameObject.SetActive(!flag);
            rightDialogPanel.gameObject.SetActive(flag);

            if(!flag)
                leftDialogPanel.ChangeInformation(phrase);
            else rightDialogPanel.ChangeInformation(phrase);
        }else SceneManager.LoadScene("Level 1");
    }
}
