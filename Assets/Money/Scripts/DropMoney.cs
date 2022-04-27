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
        GameObject uiCanvas = GameObject.Find("UIController");
        UIController money = uiCanvas.GetComponent<UIController>();
        money.changeMoney(fixdedGold);
        TakeAdditionalGold(position);
    }
    

    private void TakeAdditionalGold(Vector3 position)
    {
        if (Random.Range(0, 100) <= percentOfDropping)
        {
            //Debug.Log("I am here");
            _gold = Instantiate(goldPrefub);
            _gold.transform.position = position;
           // gold.transform.SetParent(transform);
            //gold.transform.localPosition = new Vector3(0, 0, 0);
            _gold.GetComponent<processAdditionalGold>().setAdditionalGold(additionalGold);
           // gold.transform.localPosition = ;
            
        }
    }
}
