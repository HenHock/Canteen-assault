using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatballsAbility : Ability
{
    public float radiuHit;

    public override void Use()
    {
        Debug.Log("Meat");
        throw new System.NotImplementedException(); 
    }

    public override Ability Get(Abilities ability)
    {
        if (ability == Abilities.meatballsAbility)
            return gameObject.GetComponent<MeatballsAbility>();
        return null;
    }
}
