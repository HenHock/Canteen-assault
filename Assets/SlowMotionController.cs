using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionController : MonoBehaviour
{
    public static Action startSlowMo;

    public float slowMoValue = 0.07f;
    public float slowMoDuration = 10f;

   // public float perspectiveZoomSpeed = .5f;
    //public Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        startSlowMo = SlowMotion;
    }
    
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = Math.Clamp(Time.timeScale, 0.0f, 1.0f);
        Time.fixedDeltaTime = Math.Clamp(Time.fixedDeltaTime, 0.0f, 0.02f);
        Time.timeScale += (1f / slowMoDuration) * Time.unscaledDeltaTime;
        Time.fixedDeltaTime += (0.02f / slowMoDuration) * Time.unscaledDeltaTime;
    }
    

    public void SlowMotion()
    {
        Time.timeScale = slowMoValue;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        //camera.fieldOfView += deltaMagnitudediff * perspectiveZoomSpeed;
        //camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 100f, LeftUp.transform.position.y * 10);
    }
}
