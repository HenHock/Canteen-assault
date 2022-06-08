using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReturnScript : MonoBehaviour
{
    public static Action getReward;
    [SerializeField] private GameObject parentPannel;
    public void onClick()
    {
        //play adds
        
        
    }

    public void getAdditionalCake()
    {
        ResourcesManager.Change(ResourceType.Life, 3);
        CakeControllerScript.AddCake();
        Time.timeScale = 1;
        parentPannel.SetActive(false);
    }

    private void Start()
    {
        getReward = getAdditionalCake;
    }
}
