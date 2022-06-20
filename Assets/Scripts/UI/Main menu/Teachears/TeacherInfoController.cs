using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class TeacherInfoController : MonoBehaviour
{
    /*
     * Script for controll information on the panel
     */
    [System.Serializable]
    private struct levelTeacherInfo
    {
        public TeacherInfo level_1;
        public TeacherInfo level_2;
        public TeacherInfo level_3;
    };

    [SerializeField] private GameObject schoolPanel;
    [SerializeField] private List<levelTeacherInfo> teacherInfoList;

    [SerializeField] private GameObject levelTeacherInfoButton_1;
    [SerializeField] private GameObject levelTeacherInfoButton_2;
    [SerializeField] private GameObject levelTeacherInfoButton_3;

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject previouslyButton;

    [SerializeField] private BuyUpgradeButton upgradeButton;
    [SerializeField] private BackupUpgradeButton backupButton;

    [SerializeField] private Sprite selectedButton;
    [SerializeField] private Sprite unSelectedButton;
    [SerializeField] private Sprite disableButton;
    [SerializeField] private Sprite enableButton; 

    public int indexT { get; set; } = 0;

    private void Awake()
    {
        foreach(levelTeacherInfo info in teacherInfoList)
            if(!ES3.Load(info.level_1.prefab.name, false))
                ES3.Save(info.level_1.prefab.name, true);
    }

    public void NextTeachearInfo()
    {
        indexT++;
        SetFirstLevelTeacherInfo();

        previouslyButton.SetActive(true);

        if (indexT == teacherInfoList.Count-1)
            nextButton.SetActive(false);
        else nextButton.SetActive(true);
    }

    public void PreviouslyTeacherInfo()
    {
        indexT--;
        SetFirstLevelTeacherInfo();

        nextButton.SetActive(true);

        if (indexT == 0)
            previouslyButton.SetActive(false);
        else previouslyButton.SetActive(true);
    }

    public void SetFirstLevelTeacherInfo()
    {
        schoolPanel.GetComponent<TeacherInfoDisplay>().ChangeTeacherInfo(teacherInfoList[indexT].level_1);

        SelectButton(levelTeacherInfoButton_1);
        UnselectButton(levelTeacherInfoButton_2);
        UnselectButton(levelTeacherInfoButton_3);
        SettingUpgradeBackupButton(teacherInfoList[indexT].level_1);
    }

    public void SetSecondLevelTeacherInfo()
    {
        schoolPanel.GetComponent<TeacherInfoDisplay>().ChangeTeacherInfo(teacherInfoList[indexT].level_2);

        SelectButton(levelTeacherInfoButton_2);
        UnselectButton(levelTeacherInfoButton_1);
        UnselectButton(levelTeacherInfoButton_3);
        SettingUpgradeBackupButton(teacherInfoList[indexT].level_2);

        if (teacherInfoList[indexT].level_3.available)
            DisableButton(backupButton.gameObject);
        else EnableButton(upgradeButton.gameObject);
    }

    public void SetThirdLevelTeacherInfo()
    {
        schoolPanel.GetComponent<TeacherInfoDisplay>().ChangeTeacherInfo(teacherInfoList[indexT].level_3);

        SelectButton(levelTeacherInfoButton_3);
        UnselectButton(levelTeacherInfoButton_2);
        UnselectButton(levelTeacherInfoButton_1);

        SettingUpgradeBackupButton(teacherInfoList[indexT].level_3);

        if (!teacherInfoList[indexT].level_2.available)
            DisableButton(upgradeButton.gameObject);
        else EnableButton(upgradeButton.gameObject);

        if(teacherInfoList[indexT].level_3.available)
            EnableButton(backupButton.gameObject);
    }

    private void EnableButton(GameObject button)
    {
        button.GetComponent<Image>().sprite = enableButton;
        button.GetComponent<Button>().enabled = true;
    }

    private void SelectButton(GameObject button)
    {
        button.transform.localScale = Vector3.one*1.2f;
        button.GetComponent<Image>().sprite = selectedButton;
        button.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }

    private void UnselectButton(GameObject button)
    {
        button.transform.localScale = Vector3.one;
        button.GetComponent<Image>().sprite = unSelectedButton;
        button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    private void DisableButton(GameObject button)
    {
        button.GetComponent<Image>().sprite = disableButton;
        button.GetComponent<Button>().enabled = false;
    }

    public void SettingUpgradeBackupButton(TeacherInfo teacherInfo)
    {
        upgradeButton.Enable(teacherInfo);
        backupButton.Enable(teacherInfo);
    }
}
