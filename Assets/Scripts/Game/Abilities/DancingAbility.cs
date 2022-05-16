using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DancingAbility : Ability
{
    public int duration;

    public override void Use()
    {
        Collider[] targets = Physics.OverlapSphere(Vector3.zero, 100f, DataManager.ENEMY_LAYER_MASK);

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
