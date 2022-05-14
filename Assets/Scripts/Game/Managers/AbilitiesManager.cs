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

    private void Awake()
    {
        abilities = new Dictionary<Abilities, Ability>()
        {
            {Abilities.dancingAbility, new DancingAbility()},
            {Abilities.meatballsAbility, new MeatballsAbility()}
        };
        
        //Ability[] abilitiesArray = transform.GetComponentsInChildren<Ability>();
        //int index = 0;
        //foreach(KeyValuePair<Abilities, Ability> kvp in abilities)
        //{
        //    var newItem = new KeyValuePair<Abilities, Ability>(kvp.Key, abilitiesArray[index]);

        //    index++;
        //}
    }

    public static Ability GetAbility(Abilities ability)
    {
        return abilities[ability];
    }
}
