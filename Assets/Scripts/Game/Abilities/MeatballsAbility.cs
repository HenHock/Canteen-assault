using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatballsAbility : Ability
{
    public float radiuHit;
    [SerializeField] private GameObject aimPrefab; // ������ �������, ������� ����� �������������� ��� ������������.

    public override void Use()
    {
        if (Input.touchCount == 1)
        {
            GameObject dragObject = Instantiate(aimPrefab);
            dragObject.transform.position = Vector3.zero;

        }
    }

    public override Ability Get(Abilities ability)
    {
        if (ability == Abilities.meatballsAbility)
            return gameObject.GetComponent<MeatballsAbility>();
        return null;
    }
}
