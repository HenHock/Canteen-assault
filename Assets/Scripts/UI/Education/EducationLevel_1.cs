using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EducationLevel_1 : MonoBehaviour
{
    private void Awake()
    {
        if (GlobalApplicationData.IsFirstLaunch)
        {
            gameObject.SetActive(true);
        }
    }
}
