using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplay : MonoBehaviour
{
    [SerializeField] private GameObject leftAbilityButton;
    public Abilities firstAbility;

    [SerializeField] private GameObject rightAbilityButton;
    public Abilities secondAbility;

    public static Action<Abilities> onDeactivateButton;
    public static Action<Abilities> onActivateButton;
    public static Action<Abilities, Sprite> onChangeArtWork;

    private void Start()
    {
        AbilitiesManager.SetAbility(firstAbility, leftAbilityButton);
        AbilitiesManager.SetAbility(secondAbility, rightAbilityButton);

        onDeactivateButton = DeactivateButton;
        onActivateButton = ActivateButton;
        onChangeArtWork = changeArtwork;
    }

    private void DeactivateButton(Abilities ability)
    {
        if(firstAbility == ability)
            leftAbilityButton.GetComponent<Button>().enabled = false;
        else rightAbilityButton.GetComponent<Button>().enabled = false;
    }

    private void ActivateButton(Abilities ability)
    {
        if (firstAbility == ability)
            leftAbilityButton.GetComponent<Button>().enabled = true;
        else rightAbilityButton.GetComponent<Button>().enabled = true;
    }

    public void changeArtwork(Abilities ability, Sprite newArtwork)
    {
        if (firstAbility == ability)
            leftAbilityButton.GetComponent<Image>().sprite = newArtwork;
        else rightAbilityButton.GetComponent<Image>().sprite = newArtwork;
    }
}
