using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TeacherInfoDisplay : MonoBehaviour
{
    /*
     * Script which display information on the panel
     */
    [SerializeField] private TeacherInfo teacherInfo;
    [SerializeField] private TextMeshProUGUI nameTeacher;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private TextMeshProUGUI attackSpeed;
    [SerializeField] private TextMeshProUGUI attackRadius;
    [SerializeField] private TextMeshProUGUI costToBuy;
    [SerializeField] private Image image;

    void Start()
    {
        GetComponent<TeacherInfoController>().SetFirstLevelTeacherInfo();
    }

    public void ChangeTeacherInfo(TeacherInfo teacherInfo)
    {
        this.teacherInfo = teacherInfo;
        SetTeacherInfo(); ;
    }

    private void SetTeacherInfo()
    {
        nameTeacher.text = teacherInfo.nameTeacher;
        description.text = teacherInfo.description;
        damage.text = teacherInfo.damage.ToString() + "x" + teacherInfo.countAttack;
        attackSpeed.text = teacherInfo.attackSpeed.ToString();
        attackRadius.text = teacherInfo.attackRadius.ToString();
        image.sprite = teacherInfo.image;
        costToBuy.text = teacherInfo.costToBuy.ToString();

        teacherInfo.available = ES3.Load(teacherInfo.prefab.name, false);
    }
}
