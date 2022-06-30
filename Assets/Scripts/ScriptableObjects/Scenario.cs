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

    private int index = 0;

    private void Awake()
    {
        index = 0;
    }

    public Phrases GetNextPhrases()
    {
        Phrases phrase = scenario[index++];
        return phrase;
    }

    public bool isNext()
    {
        if (index < scenario.Count)
            return true;

        return false;
    }
}
