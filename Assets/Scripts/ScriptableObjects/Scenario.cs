using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Phrases
{
    public string speaker;
    public string messageText;
    public string note;
    public Sprite sprite;
}

[CreateAssetMenu(fileName = "New Scenario", menuName = "Scenario")]
public class Scenario : ScriptableObject
{
    [SerializeField] private List<Phrases> scenario;

    public Phrases GetNextPhrases()
    {
        Phrases phrase = scenario[0];
        scenario.RemoveAt(0);
        return phrase;
    }

    public bool isEmpty()
    {
        if (scenario.Count > 0)
            return false;

        return true;
    }
}
