using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatballsShotScirpt : MonoBehaviour
{
    private Transform meatball;
    [SerializeField] GameObject explosionPrefub;

    private void Start()
    {
        meatball = transform.GetChild(0);

        for(int i = 0; i < 15; i++)
        {
            GameObject newMeatball = Instantiate(meatball.gameObject);
            newMeatball.transform.SetParent(transform);
            newMeatball.transform.localPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(4f,8f), Random.Range(-1f, 1f));
            newMeatball.transform.Rotate(new Vector3(Random.Range(0f, 180f), Random.Range(0f, 180f), Random.Range(0f, 180f)));
        }

        StartCoroutine(DestroyAll());
    }

    private IEnumerator DestroyAll()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        if (explosionPrefub)
            Instantiate(explosionPrefub, transform.position, Quaternion.Euler(0, 0, 0));
    }
}
