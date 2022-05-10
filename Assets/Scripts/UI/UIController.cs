using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private void Start()
    {
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
