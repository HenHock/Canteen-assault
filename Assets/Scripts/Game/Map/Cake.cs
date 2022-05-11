using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{

    public int countStar { get; set; } = 3;

    [SerializeField] private GameObject titleText;
    [SerializeField] private GameObject statistics;

    public static Action<int> EatCake;
    public static Action<bool> EndGame;

    private void Awake()
    {
        ResourcesManager.OnResourcesAmountChanged += HandleLifeAmountChanged;
        EatCake = eatCakeRealise;
        EndGame = endGameRealise;
    }

    private void OnDestroy()
    {
        ResourcesManager.OnResourcesAmountChanged -= HandleLifeAmountChanged;
    }

    private void HandleLifeAmountChanged(ResourceType type, float amount)
    {
        if(type != ResourceType.Life)
        {
            return;
        }

        if(amount<=0)
        {
            EndGame(false);
        }
    }


    public void eatCakeRealise(int damage)
    {
        ResourcesManager.Change(ResourceType.Life, -damage);
    }

    public void endGameRealise(bool flag)
    {
        DataManager.uIController.endGamePanel.Open();

        if (flag)
        {
            Win();
        }
        else
        {
            Lose();
        }
        Time.timeScale = 0;
    }

    private void Win()
    {
        // You win
        titleText.GetComponent<Text>().text = "You win!";
        statistics.GetComponent<Text>().text = $"You earned {countStar} star!";
    }

    private void Lose()
    {
        // You lose
        titleText.GetComponent<Text>().text = "You lose :(";
        statistics.GetComponent<Text>().text = "You can try again!";
    }
}
