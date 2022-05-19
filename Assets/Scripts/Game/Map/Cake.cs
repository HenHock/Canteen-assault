using Assets.Scripts.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
    public int countStar { get; set; } = 3;

    [SerializeField] private GameObject nextCakePrefab;

    public static Action<int> EatCake;
    public static Action<bool> EndGame;

    private void Start()
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
        if (type != ResourceType.Life)
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
        changeCakeDisplay();
    }

    public void endGameRealise(bool flag)
    {
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
        if (nextCakePrefab) {
            Vector3 pos = transform.position;
            GameObject newCakePrefab = Instantiate(nextCakePrefab);
            newCakePrefab.transform.position = pos;

            Destroy(gameObject);
        }
    }
}
