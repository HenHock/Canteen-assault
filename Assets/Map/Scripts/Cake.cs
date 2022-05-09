using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
    [SerializeField] private int health;

    public int countStar;

    GameObject titleText;
    GameObject statistics;

    public void eatCake(int damage)
    {
        health -= damage;
        if (health <= 0)
            EndGame(false);
    }

    public void EndGame(bool flag)
    {
        DataManager.uIController.endGamePanel.Open();

        titleText = GameObject.Find("TitleText");
        statistics = GameObject.Find("Statistics");

        if (flag)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }

    private void Win()
    {
        // You win
        titleText.GetComponent<Text>().text = "You win!";
        statistics.GetComponent<Text>().text = $"Íou earned {countStar} star";
    }

    private void Lose()
    {
        // You lose
        titleText.GetComponent<Text>().text = "You lose!";
        statistics.GetComponent<Text>().text = "You nothing eared :(";
    }
}
