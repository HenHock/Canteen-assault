using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
    [SerializeField] private int health;

    public int countStar;

    public void eatCake(int damage)
    {
        health -= damage;
        if (health == 0)
            EndGame(false);
    }

    public void EndGame(bool flag)
    {
        DataManager.uIController.endGamePanel.SetActive(true);
        GameObject titleText = GameObject.Find("TitleText");
        GameObject statistics = GameObject.Find("Statistics");


        if (flag)
        {
            // You win
            titleText.GetComponent<Text>().text = "You win!";
            statistics.GetComponent<Text>().text = $"Íou earned {countStar} star";
        }
        else
        {
            // You lose
            titleText.GetComponent<Text>().text = "You lose!";
            statistics.GetComponent<Text>().text = "You nothing eared :(";
        }
    }
}
