using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������, ������� �������� � ��������� ����������� ������� ����� ����������.
/// </summary>
public class RadiusAttackDisplay : MonoBehaviour
{
    public void ActivateOrDeactivate()
    {
        DataManager.isRadiusAttackDisplay = !DataManager.isRadiusAttackDisplay;
        foreach (GameObject item in DataManager.radiusAttackObjects)
        {
            if (item != null)
                item.SetActive(DataManager.isRadiusAttackDisplay);
        }

    }
}
