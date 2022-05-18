using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPoint : MonoBehaviour
{
    public Enemy  enemy { get; private set; }
    public Vector3 position => transform.position;
    public float colliderSize { get; private set; }

    private void Awake()
    {
        enemy = transform.root.GetComponent<Enemy>();
        colliderSize = GetComponent<Collider>().transform.localScale.x;
    }
}
