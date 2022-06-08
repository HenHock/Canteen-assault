using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreNoButton : MonoBehaviour
{
    [SerializeField] private GameObject parentPannel;
    public void onClick()
    {
        UIManager.OnBlurAction(false);
        Time.timeScale = 1;
        CakeControllerScript.ForceLose();
        parentPannel.SetActive(false);
    }

}
