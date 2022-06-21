using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    private Enemy target;

    public List<int> burnTickTimer = new List<int>();

    private void Awake()
    {
        target = GetComponent<Enemy>();
    }

    public void ApplyBurn(int ticks, int damage, float timeIteration)
    {
        if(burnTickTimer.Count <= 0)
        {
            burnTickTimer.Add(ticks);
            target.isPoison = true;
            StartCoroutine(Burn(damage, timeIteration));
        }
        else
        {
            burnTickTimer.Add(ticks);
        }
    }

    IEnumerator Burn(int damage, float timeIteration)
    {
        while (burnTickTimer.Count > 0)
        {
            for(int i = 0; i < burnTickTimer.Count; i++)
            {
                burnTickTimer[i]--;
            }
            target.TakeDamage(damage);
            burnTickTimer.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(timeIteration);
        }
        target.isPoison=false;
    }
}
