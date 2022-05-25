using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TeacherInfoDisplay : MonoBehaviour
{
    [SerializeField] private TeacherInfo teacherInfo;
    [SerializeField] private TextMeshProUGUI nameTeacher;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private TextMeshProUGUI attackSpeed;
    [SerializeField] private TextMeshProUGUI attackRadius;
    [SerializeField] private Image image;

    void Start()
    {
        nameTeacher.text = teacherInfo.nameTeacher;
        description.text = teacherInfo.description;
        damage.text = teacherInfo.damage.ToString();
        attackSpeed.text = teacherInfo.attackSpeed.ToString();
        attackRadius.text = teacherInfo.attackRadius.ToString();
        image.sprite = teacherInfo.image;
    }

    public void ChangeTeacherInfo(TeacherInfo teacherInfo)
    {
        this.teacherInfo = teacherInfo;

        nameTeacher.text = teacherInfo.nameTeacher;
        description.text = teacherInfo.description;
        damage.text = teacherInfo.damage.ToString();
        attackSpeed.text = teacherInfo.attackSpeed.ToString();
        attackRadius.text = teacherInfo.attackRadius.ToString();
        image.sprite = teacherInfo.image;
    }
}
