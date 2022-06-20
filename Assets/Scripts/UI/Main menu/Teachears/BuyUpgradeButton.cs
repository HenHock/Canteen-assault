using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UI;
using UnityEngine.UI;

public class BuyUpgradeButton : MonoBehaviour
{
    private PanelController confirmPanel;
    private int costStarsToBuyUpgrade;
    private TeacherInfo teacherInfo;

    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Button confirmButton;

    public void onClick()
    {
        confirmPanel?.Open();

        description.text = $"Do you want to buy this upgrade for {costStarsToBuyUpgrade} stars?";
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(confirmToBuy);
    }

    public void Enable(TeacherInfo teacherInfo)
    {
        gameObject.SetActive(!teacherInfo.available);

        confirmPanel = UIController.onGetPanel(PanelType.confirmPanel).GetComponent<PanelController>();
        costStarsToBuyUpgrade = teacherInfo.costStarsToBuy;
        this.teacherInfo = teacherInfo;
    }

    private void confirmToBuy()
    {
        if(ResourcesManager.Get(ResourceType.Star) >= costStarsToBuyUpgrade)
        {
            ResourcesManager.Change(ResourceType.Star, -costStarsToBuyUpgrade);
            teacherInfo.available = true;
            ES3.Save(teacherInfo.prefab.name, teacherInfo.available);
            GetComponentInParent<TeacherInfoController>().SettingUpgradeBackupButton(teacherInfo);
        }
        else
        {
            UIController.onGetPanel(PanelType.messageBoxPanel).GetComponent<PanelController>().Open();
        }
    }
}
