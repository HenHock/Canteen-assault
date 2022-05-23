using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AbilityDisplay : MonoBehaviour
{
    [SerializeField] private GameObject leftAbilityButton;
    public Abilities firstAbility;

    [SerializeField] private GameObject rightAbilityButton;
    public Abilities secondAbility;

    public static Action<Abilities> onDeactivateButton;
    public static Action<Abilities> onActivateButton;
    public static Action<Abilities, Sprite, UnityAction> onChangeArtwork;

    private void Start()
    {
        AbilitiesManager.SetAbility(firstAbility, leftAbilityButton);
        AbilitiesManager.SetAbility(secondAbility, rightAbilityButton);

        onDeactivateButton = DeactivateButton;
        onActivateButton = ActivateButton;
        onChangeArtwork = changeArtwork;
    }

    private void DeactivateButton(Abilities ability)
    {
        if (firstAbility == ability)
        {
            leftAbilityButton.GetComponent<Button>().enabled = false;
            changeColor(ability, leftAbilityButton.GetComponent<Image>());
        }
        else 
        { 
            rightAbilityButton.GetComponent<Button>().enabled = false;
            changeColor(ability, rightAbilityButton.GetComponent<Image>()); 
        }
    }

    private void changeColor(Abilities ability, Image imgButton)
    {
        if(imgButton.color == Color.white)
            imgButton.color = Color.gray;
        else imgButton.color = Color.white;
    }

    private void ActivateButton(Abilities ability)
    {
        if (firstAbility == ability)
        {
            leftAbilityButton.GetComponent<Button>().enabled = true;
            changeColor(ability, leftAbilityButton.GetComponent<Image>());
        }
        else
        {
            rightAbilityButton.GetComponent<Button>().enabled = true;
            changeColor(ability, rightAbilityButton.GetComponent<Image>());
        }
    }

    /// <summary>
    /// Меняет иконку кнопки и изменяет дейсвия при нажатие на кнопку
    /// </summary>
    /// <param name="ability">Способность, чью кнопку надо изменить</param>
    /// <param name="newArtwork">Новая иконка для кнопки</param>
    /// <param name="unityAction">Новое действие на левый клик для кнопки</param>
    public void changeArtwork(Abilities ability, Sprite newArtwork, UnityAction unityAction)
    {
        if (firstAbility == ability)
        {
            leftAbilityButton.GetComponent<Image>().sprite = newArtwork;
            leftAbilityButton.GetComponent<Button>().onClick.RemoveAllListeners();
            leftAbilityButton.GetComponent<Button>().onClick.AddListener(unityAction);
        }
        else
        {
            rightAbilityButton.GetComponent<Image>().sprite = newArtwork;
            rightAbilityButton.GetComponent<Button>().onClick.RemoveAllListeners();
            rightAbilityButton.GetComponent<Button>().onClick.AddListener(unityAction);
        }
    }
}
