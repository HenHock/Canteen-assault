using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : TaskAbstract
{
    private int goldTimesCollected = 0;
    //private string textTask = $"Pick up coins {howMuchUse} times.";

    public override string GetTextTask()
    {
        return $"Pick up coins {howMuchUse} times.";
    }

    public override bool CheckIfComplete()
    {
        if (goldTimesCollected == howMuchUse)
            return true;
        else
            return false;
    }

    void Awake()
    {
        goldTimesCollected = 0;
        processAdditionalGold.OnGoldCollected += countTimesGoldCollected;
    }
    private void OnDestroy()
    {
        processAdditionalGold.OnGoldCollected -= countTimesGoldCollected;
    }

    private void countTimesGoldCollected()
    {
        goldTimesCollected++;
    }
}
