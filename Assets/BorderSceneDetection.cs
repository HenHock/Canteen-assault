using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderSceneDetection : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter");
    }
}
