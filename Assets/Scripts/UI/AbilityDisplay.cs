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

    private void Awake()
    {
        AbilitiesManager.SetAbility(firstAbility, leftAbilityButton);
        AbilitiesManager.SetAbility(secondAbility, rightAbilityButton);
    }
}
