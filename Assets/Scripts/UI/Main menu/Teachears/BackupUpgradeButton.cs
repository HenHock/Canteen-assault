using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackupUpgradeButton : MonoBehaviour
{
    private GameObject confirmPanel;
    private int costStarsToBuyUpgrade;
    private TeacherInfo teacherInfo;

    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private Button confirmButton;

    public void onClick()
    {
        confirmPanel?.SetActive(true);
        DataManager.activePanel = confirmPanel;

        description.text = $"Do you want to return {costStarsToBuyUpgrade} stars and will lose the ability to install this upgrade.";
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(confirmToBuy);
    }

    public void Enable(TeacherInfo teacherInfo)
    {
        if(teacherInfo.costStarsToBuy != 0)
            gameObject.SetActive(teacherInfo.available);
        else gameObject.SetActive(false);

        confirmPanel = UIController.onGetPanel(PanelType.confirmPanel);
        costStarsToBuyUpgrade = teacherInfo.costStarsToBuy;
        this.teacherInfo = teacherInfo;
    }

    private void confirmToBuy()
    {
        ResourcesManager.Change(ResourceType.Star, costStarsToBuyUpgrade);
        teacherInfo.available = false;
        ES3.Save(teacherInfo.prefab.name, teacherInfo.available);

        GetComponentInParent<TeacherInfoController>().SettingUpgradeBackupButton(teacherInfo);
    }
}
