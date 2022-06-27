using System;
using System.Collections;
using UI;
using UnityEngine;

public class CakeControllerScript : MonoBehaviour
{

    [SerializeField] private GameObject[] cake;
    [SerializeField] private PanelController restorePanel;
    private int _currentCakeLevel;
    private int _currentDamage;

    public static Action<int> EatCake;
    public static Action AddCake;
    public static Action<bool> EndGame;
    public static Action ForceLose;

    private void Start()
    {
        ResourcesManager.OnResourcesAmountChanged += HandleLifeAmountChanged;

        EatCake = EatCakeRealise;
        EndGame = EndGameReturn;
        AddCake = AddCakeDisplay;
        ForceLose = endGameRealise;
        _currentCakeLevel = cake.Length;
        
        //Debug.Log(DataManager.twentyProcentAmount);
        _currentDamage = 0;
    }
    


    private void OnDestroy()
    {
        ResourcesManager.OnResourcesAmountChanged -= HandleLifeAmountChanged;
    }

    public static void HandleLifeAmountChanged(ResourceType type, float amount)
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

    private void EatCakeRealise(int damage)
    {
        ResourcesManager.Change(ResourceType.Life, -damage);

        _currentDamage += damage;
        //Debug.Log(currentDamage);
        if(_currentDamage >= DataManager.twentyProcentAmount)
            ChangeCakeDisplay();
    }

    private void EndGameReturn(bool flag)
    {
        //Debug.Log((!flag && !DataManager.returnToGame) + " " + !restorePanel.activeInHierarchy);
        if(!restorePanel.gameObject.activeInHierarchy)
        {
            int dif = DataManager.NumberOfAllEnemies - DataManager.NumberOfDeathEnemies;
            if (!flag && !DataManager.returnToGame && dif > 1)
            {
                restorePanel.Open();
            }
            else
            {
                StartCoroutine(endGameRealise(flag));
            }
        }
    }

    private IEnumerator endGameRealise(bool flag)
    {
        yield return new WaitForSeconds(1);
        
        if (flag && ResourcesManager.Get(ResourceType.Life) > 0)
        {
            DataManager.uIController.Win();
        }
        else
        {
            DataManager.uIController.Lose();
        }
        Time.timeScale = 0;   
    }
    
    private void endGameRealise()
    {
        DataManager.uIController.Lose();
        Time.timeScale = 0;   
    }

    private void ChangeCakeDisplay()
    {
        while(_currentDamage >= DataManager.twentyProcentAmount)
        {
            if (_currentCakeLevel > 0)
            {
                _currentCakeLevel--;
                cake[_currentCakeLevel].SetActive(false);

            }
            _currentDamage -= DataManager.twentyProcentAmount;
        }
        
    }
    private void AddCakeDisplay()
    {
        _currentCakeLevel = 3;
        cake[0].SetActive(true);
        cake[1].SetActive(true);
        cake[2].SetActive(true);
    }
}
