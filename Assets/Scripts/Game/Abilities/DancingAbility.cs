using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DancingAbility : Ability
{
    /*
     * 1 - default layer
     * 9 - our custom layer, which all enemies have
     * 1 << 9 - operation which bit shift by 9 elements from 0000000001 to 1000000000;
     * 1000000000 in decimal number system is equal to 512
     * ENEMY_LAYER_MASK contain value 512
     */
    private const int ENEMY_LAYER_MASK = 1 << 9;

    public int duration;

    public override void Use()
    {
        Collider[] targets = Physics.OverlapSphere(Vector3.zero, 100f, ENEMY_LAYER_MASK);

        if(targets.Length > 0)
        {
            foreach (Collider target in targets)
                target.GetComponent<Enemy>().Dancing(duration);
        }

        DeactivateAbility(Abilities.dancingAbility);
        StartCoroutine(WaitCooldown(Abilities.dancingAbility));
    }

    public override Ability Get(Abilities ability)
    {
        if (ability == Abilities.dancingAbility)
            return gameObject.GetComponent<DancingAbility>();
        return null;
    }
}
