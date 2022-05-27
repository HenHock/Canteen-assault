using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TeacherInfoController : MonoBehaviour
{
    [System.Serializable]
    private struct levelTeacherInfo
    {
        public TeacherInfo level_1;
        public TeacherInfo level_2;
        public TeacherInfo level_3;
    };

    [SerializeField] private GameObject schoolPanel;
    [SerializeField] private List<levelTeacherInfo> teacherInfoList;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject previouslyButton;

    [SerializeField] private GameObject levelTeacherInfoButton_1;
    [SerializeField] private GameObject levelTeacherInfoButton_2;
    [SerializeField] private GameObject levelTeacherInfoButton_3;

    [SerializeField] private Sprite selectedButton;
    [SerializeField] private Sprite unselectedButton;

    public int indexT { get; set; } = 0;

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
    }

    public void SetSecondLevelTeacherInfo()
    {
        schoolPanel.GetComponent<TeacherInfoDisplay>().ChangeTeacherInfo(teacherInfoList[indexT].level_2);

        SelectButton(levelTeacherInfoButton_2);
        UnselectButton(levelTeacherInfoButton_1);
        UnselectButton(levelTeacherInfoButton_3);
    }

    public void SetThirdLevelTeacherInfo()
    {
        schoolPanel.GetComponent<TeacherInfoDisplay>().ChangeTeacherInfo(teacherInfoList[indexT].level_3);

        SelectButton(levelTeacherInfoButton_3);
        UnselectButton(levelTeacherInfoButton_2);
        UnselectButton(levelTeacherInfoButton_1);
    }

    private void SelectButton(GameObject button)
    {
        button.transform.localScale = Vector3.one*1.2f;
    }

    private void UnselectButton(GameObject button)
    {
        button.transform.localScale = Vector3.one;
    }
}
