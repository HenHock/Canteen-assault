using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProcessRestoreCakePannel : PanelController
{
    
    [SerializeField] private TMP_Text timeLeftTMP;
    private int timeLeft;

    private void OnEnable()
    {
        UIManager.OnBlurAction(true);
        Time.timeScale = 0;
       
       DataManager.returnToGame = true;
       //StartCoroutine(changeTime());
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
