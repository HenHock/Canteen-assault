using System;
using UnityEngine;
using UnityEngine.UI;

public class RestoreNoButton : MonoBehaviour
{
    [SerializeField] private GameObject parentPannel;

    public static Action GetNoReward;

    private void Start()
    {
        GetNoReward = GetNoRewardProcess;
    }

    public void onClick()
    {
        GetNoRewardProcess();
    }

    private void GetNoRewardProcess()
    {
        UIManager.OnBlurAction(false);
        Time.timeScale = 1;
        CakeControllerScript.ForceLose();
       
        parentPannel.SetActive(false);
    }
}
