using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    private int money = 0;
    public PanelController buyCharacterPanelController;
    public PanelController endGamePanel;
    public PanelController updateCharacterPanel;


    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject previouslyLevelButton;
    [SerializeField] private int startMoney;
    [SerializeField] private Text textFieldMoney;
    [SerializeField] private Text textFieldLife;

    public static Func<int, bool> changeMoney;
    public static Func<int,bool> changeLife;

    private void Awake()
    {
        changeMoney = changeMoneyProcess;
        changeLife = changeLifeProcess;
    }

    private void Awake()
    {
        DataManager.uIController = this;
        changeMoney(startMoney);

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            nextLevelButton.SetActive(true);
            previouslyLevelButton.SetActive(false);
        }else if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            nextLevelButton.SetActive(false);
            previouslyLevelButton.SetActive(true);
        }

        buyCharacterPanelController.Close();
        endGamePanel.Close();
        updateCharacterPanel.Close();
    }

    private bool changeMoneyProcess(int value)
    {
        if (money + value >= 0)
        {
            money += value;
            textFieldMoney.text = "Money: " + money;
            return true;
        }
        return false;
    }

    private bool changeLifeProcess(int value)
    {
        textFieldLife.text = "Pice of cake left: " + value;
        return true;
    }
}
