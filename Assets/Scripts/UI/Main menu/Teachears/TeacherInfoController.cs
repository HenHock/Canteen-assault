using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherInfoController : MonoBehaviour
{
    [SerializeField] private GameObject schoolPanel;
    [SerializeField] private List<TeacherInfo> teacherInfoList;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject previouslyButton;
    private int index = 0;

    public void NextTeachearInfo()
    {
        index++;
        schoolPanel.GetComponent<TeacherInfoDisplay>().ChangeTeacherInfo(teacherInfoList[index]);

        previouslyButton.SetActive(true);

        if (index == teacherInfoList.Count-1)
            nextButton.SetActive(false);
        else nextButton.SetActive(true);
    }

    public void PreviouslyTeacherInfo()
    {
        index--;
        schoolPanel.GetComponent<TeacherInfoDisplay>().ChangeTeacherInfo(teacherInfoList[index]);

        nextButton.SetActive(true);

        if (index == 0)
            previouslyButton.SetActive(false);
        else previouslyButton.SetActive(true);
    }
}
