using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskAbstract : MonoBehaviour
{
    public float howMuchUse = 0;

    public abstract string GetTextTask();

    public abstract bool CheckIfComplete();
}
