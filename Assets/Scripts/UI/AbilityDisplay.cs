using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityDisplay : MonoBehaviour
{
    [SerializeField] private GameObject leftAbilityButton;
    [SerializeField] private GameObject rightAbilityButton;

    public Abilities firstAbility;
    public Abilities secondAbility;

    private void Start()
    {
        //Debug.Log(AbilitiesManager.GetAbility(firstAbility));
        SetAbility(firstAbility, leftAbilityButton);
        SetAbility(secondAbility, rightAbilityButton);
    }

    public void SetAbility(Abilities ability, GameObject button)
    {
        button.GetComponent<Image>().sprite = AbilitiesManager.GetAbility(ability).UIImage;
        button.GetComponent<Button>().onClick.AddListener(AbilitiesManager.GetAbility(ability).Use);
    }
}
