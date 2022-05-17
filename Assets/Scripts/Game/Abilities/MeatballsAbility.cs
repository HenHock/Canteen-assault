using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatballsAbility : Ability
{
    [SerializeField, Range(0f, 2f)] float radiuHit;
    [SerializeField] private GameObject aimPrefab; // Префаб объекта, который будет генерироваться для прицеливания.
    [SerializeField] private Sprite cancelAbilitySprite;
    [SerializeField] private int damage;
    private GameObject dragObject;

    public override void Use()
    {
        DataManager.isNeedToDestroy = true;
        dragObject = Instantiate(aimPrefab);
        dragObject.transform.position = Vector3.zero;
        dragObject.transform.localScale = new Vector3(radiuHit, 0.01f, radiuHit);
        dragObject.GetComponent<SphereCollider>().radius = radiuHit * 2.5f;
        dragObject.GetComponent<DragObject>().damage = damage;
        AbilityDisplay.onChangeArtwork(Abilities.meatballsAbility, cancelAbilitySprite, CancelButtonClick);
    }

    public override Ability Get(Abilities ability)
    {
        if (ability == Abilities.meatballsAbility)
            return gameObject.GetComponent<MeatballsAbility>();
        return null;
    }

    private void CancelButtonClick()
    {
        DataManager.isNeedToDestroy = false;
        if(dragObject)
            Destroy(dragObject);
        AbilityDisplay.onChangeArtwork(Abilities.meatballsAbility, artWork, Use);
    }
}
