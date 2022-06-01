using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3 : TaskAbstract
{
    private float goldSpent = 0;
    //[SerializeField] private static float howMuchMoneySpent = 0;
   // private string textTask = $"Spend more than {howMuchUse} coins.";

    public override string GetTextTask()
    {
        return $"Spend more than {howMuchUse} coins.";
    }

    public override bool CheckIfComplete()
    {
        if (goldSpent >= howMuchUse)
            return true;
        else
            return false;
        
    }

    void Awake()
    {
        goldSpent = 0;
        CharacterSpawn.OnSpentMoney += countSpentGold;
        CharacterUpdate.OnSpentMoneyUpdate += countSpentGold;
    }
    private void OnDestroy()
    {
        CharacterSpawn.OnSpentMoney -= countSpentGold;
        CharacterUpdate.OnSpentMoneyUpdate -= countSpentGold;
    }

    private void countSpentGold(float value)
    {
        goldSpent += value;
    }
}
