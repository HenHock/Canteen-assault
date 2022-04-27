using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour 
{
    public float damage;
    public int costToBuy;
    public int costToUpgrade;

    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private GameObject shotPrefab;

    public void onAttack()
    {
        ;
    }
}
