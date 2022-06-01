using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task4 : TaskAbstract
{
    private int countNumberUse = 0;

    public override string GetTextTask()
    {
        return $"Use dancing ability no more than {howMuchUse} times.";
    }

    public override bool CheckIfComplete()
    {
        if (countNumberUse == howMuchUse)
            return true;
        else
            return false;
    }

    void Awake()
    {
        countNumberUse = 0;
        DancingAbility.OnDancingAbilityUse += countDancingAbilityUse;
    }
    private void OnDestroy()
    {
        DancingAbility.OnDancingAbilityUse -= countDancingAbilityUse;
    }

    private void countDancingAbilityUse()
    {
        countNumberUse++;
    }
}
