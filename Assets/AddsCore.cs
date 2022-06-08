using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsCore : MonoBehaviour, IUnityAdsShowListener
{

    [SerializeField] private bool _testMode = true;

    private string _gameId = "4789683";
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(_gameId, _testMode);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show("");
    }
    

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Something wrong with ads");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if(showCompletionState == UnityAdsShowCompletionState.COMPLETED)
            ReturnScript.getReward();
        else
        {
            CakeControllerScript.ForceLose();
        }
    }
}
