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

    
    [SerializeField] private Color disableButton;
    [SerializeField] private Color enableButton;

    [SerializeField] private EducationController educationController;

    public int indexT { get; set; } = 0;

    private void Awake()
    {
        foreach(levelTeacherInfo info in teacherInfoList)
            if(!ES3.Load(info.level_1.prefab.name, false))
                ES3.Save(info.level_1.prefab.name, true);

        if (GlobalApplicationData.IsFirstLaunch)
        {
            educationController.SchoolEnter();
            DisableButton(nextButton);
            DisableButton(levelTeacherInfoButton_1);

            DisableButton(levelTeacherInfoButton_3);
            DisableButton(backupButton.gameObject);
        }
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
        upgradeButton.gameObject.SetActive(false);
        backupButton.gameObject.SetActive(false);
    }

    public void SetSecondLevelTeacherInfo()
    {
        schoolPanel.GetComponent<TeacherInfoDisplay>().ChangeTeacherInfo(teacherInfoList[indexT].level_2);

        SelectButton(levelTeacherInfoButton_2);
        UnselectButton(levelTeacherInfoButton_1);
        UnselectButton(levelTeacherInfoButton_3);
        EnableButton(upgradeButton.gameObject);
        SettingUpgradeBackupButton(teacherInfoList[indexT].level_2);

        if (teacherInfoList[indexT].level_3.available)
            DisableButton(backupButton.gameObject);
        //else EnableButton(upgradeButton.gameObject);
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
        button.GetComponent<Image>().color = enableButton;

        button.GetComponent<AnimationButton>()?.ActivateAnimatedButton();
        button.GetComponent<ScaleAnimationButton>()?.startAnimation();
    }
    
    private void DisableButton(GameObject button)
    {
        button.GetComponent<Image>().color = disableButton;

        button.GetComponent<AnimationButton>()?.DeactibvateAnimatedButton();
        button.GetComponent<ScaleAnimationButton>()?.stopAnimation();
    }

    private void SelectButton(GameObject button)
    {
        button.transform.localScale = Vector3.one*1.2f;
        button.transform.localScale = new Vector3(0.55f, 0.55f, 0.55f);
    }

    private void UnselectButton(GameObject button)
    {
        button.transform.localScale = Vector3.one;
        button.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    public void SettingUpgradeBackupButton(TeacherInfo teacherInfo)
    {
        upgradeButton.Enable(teacherInfo);
        backupButton.Enable(teacherInfo);

        EnableButton(backupButton.gameObject);
    }
}
