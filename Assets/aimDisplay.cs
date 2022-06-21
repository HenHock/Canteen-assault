using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimDisplay : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyByTime(0.3f));
    }

    private IEnumerator DestroyByTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
