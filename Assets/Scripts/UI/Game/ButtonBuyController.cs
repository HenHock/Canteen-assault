using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonBuyController : MonoBehaviour
{
    private void Start()
    {
        setEneble();
    }

    private void OnEnable()
    {
        setEneble();
    }

    private void setEneble()
    {
        if (Convert.ToInt32(GetComponentInChildren<TextMeshProUGUI>().text) > ResourcesManager.Get(ResourceType.Money))
        {
            GetComponent<Button>().enabled = false;
            GetComponent<AnimationButton>()?.DeactibvateAnimatedButton();
            GetComponent<ScaleAnimationButton>()?.stopAnimation();
        }
        else
        {
            GetComponent<Button>().enabled = true;
            GetComponent<AnimationButton>()?.ActivateAnimatedButton();
            GetComponent<ScaleAnimationButton>()?.startAnimation();
        }
    }
}
