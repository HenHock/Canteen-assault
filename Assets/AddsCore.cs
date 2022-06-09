using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Advertisements;
using UnityEngine;
using UnityEngine.Advertisements;


public class AddsCore : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener 
{

    [SerializeField] private bool _testMode = true;

    private string _androidGameId = "4789683";
    
    private string _iOSGameId = "4789682";

    private string _rewardedVideo = "Rewarded_Android";
    private string _iOSAdUnitId = "Rewarded_iOS";
    private string _gameId;

    public static Action ShowAdds;


    private void Awake()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Initialize();
    }
    
    public void Initialize()
    {
       
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    // Start is called before the first frame update
    void Start()
    {
        ShowAdds = ShowRewardedVideo;
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(_rewardedVideo, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ads start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Ads click");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(_gameId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            ReturnScript.getReward();

            // Load another ad:
            Advertisement.Load(_gameId);
        }
        else
        {
            RestoreNoButton.GetNoReward();
        }
    }
}
