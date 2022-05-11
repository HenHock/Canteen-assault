using Assets.Scripts.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMoney : MonoBehaviour
{
    [SerializeField] private int fixdedGold = 0;
    [SerializeField] private int additionalGold = 0;
    [SerializeField] private int percentOfDropping = 0;

    [SerializeField] private GameObject goldPrefub;
    private GameObject _gold;

    public void Drop(Vector3 position)
    {
        ResourcesManager.Change(ResourceType.Money, fixdedGold);

        TakeAdditionalGold(position);
    }
    

    private void TakeAdditionalGold(Vector3 position)
    {
        if (Random.Range(0, 100) <= percentOfDropping)
        {
            _gold = Instantiate(goldPrefub);
            _gold.transform.position = position;
            _gold.GetComponent<processAdditionalGold>().setAdditionalGold(additionalGold);            
        }
    }
}
