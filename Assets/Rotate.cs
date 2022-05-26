using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject rotate;
    Tween tween;
    // Start is called before the first frame update
    void Start()
    {
        //transform.DORotate(Vector3.right, 1, RotateMode.WorldAxisAdd);
        Vector3 to = new Vector3(0, 90, 0);

        transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime);
    }

   
}
