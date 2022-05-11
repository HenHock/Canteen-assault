using UnityEngine;
using UnityEngine.UI;
using System;

public class UIController : MonoBehaviour
{
    private int money = 0;
    public PanelController buyCharacterPanelController;
    public PanelController endGamePanel;
    public PanelController updateCharacterPanel;

    [SerializeField] private int startMoney;
    [SerializeField] private Text textFieldMoney;
    [SerializeField] private Text textFieldLife;

    public static Func<int, bool> changeMoney;
    public static Func<int,bool> changeLife;

    private void Awake()
    {
        changeMoney = changeMoneyProcess;
        changeLife = changeLifeProcess;

        DataManager.uIController = this;
        changeMoney(startMoney);

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
