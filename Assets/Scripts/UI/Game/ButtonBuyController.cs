using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonBuyController : MonoBehaviour
{
    [SerializeField]
    private Sprite desiableSprite;

    [SerializeField]
    private Sprite enableSprite;

    private void Start()
    {
        if (Convert.ToInt32(GetComponentInChildren<TextMeshProUGUI>().text) > ResourcesManager.Get(ResourceType.Money))
        {
            GetComponent<Button>().enabled = false;
            GetComponent<Image>().sprite = desiableSprite;
        }
        else
        {
            GetComponent<Button>().enabled = true;
            GetComponent<Image>().sprite = enableSprite;
        }
    }

    private void OnEnable()
    {
        if (Convert.ToInt32(GetComponentInChildren<TextMeshProUGUI>().text) > ResourcesManager.Get(ResourceType.Money))
        {
            GetComponent<Button>().enabled = false;
            GetComponent<Image>().sprite = desiableSprite;
        }
        else
        {
            GetComponent<Button>().enabled = true;
            GetComponent<Image>().sprite = enableSprite;
        }
    }
}
