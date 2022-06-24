using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProcessRestoreCakePannel : PanelController
{
    
    [SerializeField] private TMP_Text timeLeftTMP;
    [SerializeField] private Button cancelButton;

    [SerializeField] private GameObject endGamePannel;
   // [SerializeField] private Button pauseButton;
   // [SerializeField] private Button playButton;
    private int timeLeft;

    private void OnEnable()
    {
        UIManager.OnBlurAction(true);
        Time.timeScale = 0;
       
       DataManager.returnToGame = true;
       uiInLevel.SetActive(false);
       //cancelButton.gameObject.SetActive(false);
       //StartCoroutine(putButton());
       //StartCoroutine(changeTime());
    }
    
    private IEnumerator putButton()
    {
        yield return new WaitForSeconds(3f);
        cancelButton.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if (!endGamePannel.activeInHierarchy)
        {
            UIManager.OnBlurAction(false);
            uiInLevel.SetActive(true);
        }

    }
    /*
    private IEnumerator changeTime()
    {
        while (timeLeft > 0)
        {
            timeLeftTMP.text = timeLeft.ToString();
            timeLeft--;
            yield return new WaitForSeconds(1f);
        }

        Close();
    }

    private void Close()
    {
        UIManager.OnBlurAction(false);
        //Time.timeScale = 1;
        Debug.Log("closing");
        CakeControllerScript.EndGame(false);
        gameObject.SetActive(false);
       
    }
   */ 
    void Awake()
    {
        DataManager.returnToGame = false;
        timeLeft = 5;
    }
}
