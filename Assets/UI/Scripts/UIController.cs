using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int money = 0;
    public PanelController buyCharacterPanelController;
    public GameObject endGamePanel;

    [SerializeField] private int startMoney;
    [SerializeField] private Text textFieldMoney;

    private void Start()
    {
        changeMoney(startMoney);

        buyCharacterPanelController.Close();
        endGamePanel.SetActive(false);
    }

    public bool changeMoney(int value)
    {
        if (money + value >= 0)
        {
            money += value;
            textFieldMoney.text = "Money: " + money;
            return true;
        }
        return false;
    }
}
