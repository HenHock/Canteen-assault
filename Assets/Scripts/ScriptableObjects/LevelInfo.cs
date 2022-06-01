using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New LevelInfo", menuName = "LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public GameObject task_1;
    public GameObject task_2;
    public int countStarsRecieved;
    public string sceneName;
}
