using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : TaskAbstract
{
    public override string GetTextTask()
    {
        return $"Finish a level with exactly {howMuchUse} pieces of cake.";
    }

    public override bool CheckIfComplete()
    {
        if (ResourcesManager.Get(ResourceType.Life) == howMuchUse)
            return true;
        else
            return false;
    }
    //hi
}
