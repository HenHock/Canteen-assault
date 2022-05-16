using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Abilities
{
    meatballsAbility,
    dancingAbility
};

public class AbilitiesManager : MonoBehaviour
{
    private static Dictionary<Abilities, Ability> abilities;
    private static Ability[] abilitiesArray;

    private void Awake()
    {
        abilities = new Dictionary<Abilities, Ability>()
        {
            {Abilities.dancingAbility, null},
            {Abilities.meatballsAbility, null}
        };

        abilitiesArray = transform.GetComponentsInChildren<Ability>();
    }

    public static Ability GetAbility(Abilities ability)
    {
        return abilities[ability];
    }

    public static void SetAbility(Abilities ability, GameObject button)
    {
        if (abilities.Count == abilitiesArray.Length)
        {
            foreach (var item in abilitiesArray)
                if(item.Get(ability) != null)
                   abilities[ability] = item.Get(ability);

            button.GetComponent<Image>().sprite = abilities[ability].artWork;
            button.GetComponent<Button>().onClick.AddListener(abilities[ability].Use);
        }
        else Debug.Log("Count of elements in dictionary of abilities is not equals count of abilities in AbilitiesManager");
    }
}
