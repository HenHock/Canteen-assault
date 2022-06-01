using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuyController : MonoBehaviour
{
    private void OnEnable()
    {
        if (Convert.ToInt32(GetComponentInChildren<Text>().text) < ResourcesManager.Get(ResourceType.Money))
        {
            gameObject.active = true;
        }
    }
}
