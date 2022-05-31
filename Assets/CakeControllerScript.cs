using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeControllerScript : MonoBehaviour
{
    public int countStar { get; set; } = 3;

    [SerializeField] private GameObject[] Cake;
    private int currentCakeLevel;
    private int currentDamage = 0;

    public static Action<int> EatCake;
    public static Action<bool> EndGame;

    private void Start()
    {
        ResourcesManager.OnResourcesAmountChanged += HandleLifeAmountChanged;

        EatCake = eatCakeRealise;
        EndGame = EndGameReturn;
        currentCakeLevel = Cake.Length;
        
        //Debug.Log(DataManager.twentyProcentAmount);
        currentDamage = 0;
    }

    private void OnDestroy()
    {
        ResourcesManager.OnResourcesAmountChanged -= HandleLifeAmountChanged;
    }

    private void HandleLifeAmountChanged(ResourceType type, float amount)
    {
        if (type != ResourceType.Life)
        {
            return;
        }

        if (amount <= 0)
        {
            EndGame(false);
        }
    }

    public void eatCakeRealise(int damage)
    {
        ResourcesManager.Change(ResourceType.Life, -damage);

        currentDamage += damage;
        //Debug.Log(currentDamage);
        if(currentDamage >= DataManager.twentyProcentAmount)
            changeCakeDisplay();
    }

    private void EndGameReturn(bool flag)
    {
        StartCoroutine(endGameRealise(flag));
    }

    private IEnumerator endGameRealise(bool flag)
    {
        yield return new WaitForSeconds(2);
        if (flag)
        {
            DataManager.uIController.Win();
        }
        else
        {
            DataManager.uIController.Lose();
        }
        Time.timeScale = 0;
    }

    private void changeCakeDisplay()
    {
        while(currentDamage >= DataManager.twentyProcentAmount)
        {
            if (currentCakeLevel > 0)
            {
                currentCakeLevel--;
                Cake[currentCakeLevel].SetActive(false);

            }
            currentDamage -= DataManager.twentyProcentAmount;
        Debug.Log($"after change {currentDamage}");
        }
        
    }
}
