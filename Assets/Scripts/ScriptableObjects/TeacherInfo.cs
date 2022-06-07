using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New TeacherInfo", menuName ="TeacherInfo")]
public class TeacherInfo : ScriptableObject
{
    public string nameTeacher;
    public string description;
    public int damage;
    public float attackSpeed;
    public float attackRadius;
    public int costToBuy;
    public Sprite image;
    public GameObject prefab;
    public TeacherInfo nextTeacherInfo;
    public bool available; // Available to buy upgrade or not
    public int costStarsToBuy; // For first level of the teacher have to equal to 0
}
