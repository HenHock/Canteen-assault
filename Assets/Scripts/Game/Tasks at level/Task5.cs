using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task5 : TaskAbstract
{
    private int countUse = 0;

    public override string GetTextTask()
    {
        return $"Use meatballs ability no more than {howMuchUse} times.";
    }

    public override bool CheckIfComplete()
    {
        if (countUse <= howMuchUse)
            return true;
        else
            return false;
    }

    void Awake()
    {
        countUse = 0;
        MeatballsAbility.OnMeatballsgAbilityUse += countMeatballsAbilityUse;
    }
    private void OnDestroy()
    {
        MeatballsAbility.OnMeatballsgAbilityUse -= countMeatballsAbilityUse;
    }

    private void countMeatballsAbilityUse()
    {
        countUse++;
    }
}
