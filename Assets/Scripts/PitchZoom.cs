using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchZoom : MonoBehaviour
{
    public float perspectiveZoomSpeed = .5f;
    public float orthoZoomSpeed = .5f;
    [SerializeField] GameObject LeftUp;
    public Camera camera;

    private void Update()
    {
        if(Input.touchCount==2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudediff = prevTouchDeltaMag - touchDeltaMag;

            camera.fieldOfView += deltaMagnitudediff * perspectiveZoomSpeed;
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 100f, LeftUp.transform.position.y*10);

        }
    }
}
