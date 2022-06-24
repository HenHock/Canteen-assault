using System;
using UnityEngine;
using UnityEngine.UI;

public class ReturnScript : MonoBehaviour
{
    public static Action getReward;
    [SerializeField] private GameObject parentPannel;

    public void onClick()
    {
        //play adds
        AddsCore.ShowAdds();

    }

    public void getAdditionalCake()
    {
        ResourcesManager.Change(ResourceType.Life, 3);
        CakeControllerScript.AddCake();
        
        Time.timeScale = 1;
        //как-то обозначить, что мы купили рекламу
        parentPannel.SetActive(false);
    }

    private void Start()
    {
        getReward = getAdditionalCake;
    }


}
