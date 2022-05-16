using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{
    public int cooldown;
    public Sprite artWork;
    public abstract void Use();
    public abstract Ability Get(Abilities ability);

    /// <summary>
    /// Ожидает cooldown и после автоматически активирует кнопку способности.
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitCooldown(Abilities ability)
    {
        yield return new WaitForSeconds(cooldown);
        AbilityDisplay.onActivateButton(ability);
    }

    /// <summary>
    /// Деактвирует кнопку способности.
    /// </summary>
    public void DeactivateAbility(Abilities ability)
    {
        AbilityDisplay.onDeactivateButton(ability);
    }
}
