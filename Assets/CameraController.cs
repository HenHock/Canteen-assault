//using Lean.Touch;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float movementTime;

    private Vector3 newPosition;
    private Vector3 dragStartPosition;
    private Vector3 dragCurrentPosition;

    [SerializeField] GameObject RightDown;
    [SerializeField] GameObject LeftUp;

    private void Awake()
    {
        newPosition = transform.position;
    }

    private void Update()
    {
        HandleTouchInput();
    }
    private void HandleTouchInput() // метод передвижение - сенсор
    {
        foreach (Touch touch in Input.touches)
        {
            if (Input.touchCount == 1 && DataManager.canMoveCamera) // касание одного пальца
            {
                if (touch.phase == TouchPhase.Began) // касается ли палец экрана и создаем плейн, куда отправляем луч
                {
                    Plane plane = new Plane(Vector3.up, Vector3.zero);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    float entry;
                    if (plane.Raycast(ray, out entry)) // если луч касается плейна, присваеваем его позицию
                    {
                        dragStartPosition = ray.GetPoint(entry);
                    }
                }
                if (touch.phase == TouchPhase.Moved) // проверяем двигается ли палец и отправляем луч
                {
                    Plane plane = new Plane(Vector3.up, Vector3.zero);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    float entry;
                    if (plane.Raycast(ray, out entry)) // если луч касается плейна передаем значения новой позиции
                    {
                        dragCurrentPosition = ray.GetPoint(entry);
                        newPosition = transform.position + dragStartPosition - dragCurrentPosition;
                    }
                }
            }
        }
        
        //newPosition.x = Mathf.Clamp(newPosition.x, RightDown.transform, , 145f);  // ограничеваем передвижение Рига по X и Z
        //newPosition.z = Mathf.Clamp(newPosition.z, -8.5f, 390f);
        transform.position = Vector3.Lerp(transform.position, putInBorders(newPosition), Time.deltaTime * movementTime); // плавное передвижение
    }

    private Vector3 putInBorders(Vector3 newPosition)
    {
        if (newPosition.x > RightDown.transform.position.x)
            newPosition.x = RightDown.transform.position.x;
        if (newPosition.x < LeftUp.transform.position.x)
            newPosition.x = LeftUp.transform.position.x;
        if (newPosition.y > LeftUp.transform.position.y)
            newPosition.y = LeftUp.transform.position.y;
        if (newPosition.y < RightDown.transform.position.y)
            newPosition.y = RightDown.transform.position.y;
        if (newPosition.z > LeftUp.transform.position.z)
            newPosition.z = LeftUp.transform.position.z;
        if (newPosition.z < RightDown.transform.position.z)
            newPosition.z = RightDown.transform.position.z;
        return newPosition;
    }



    //private Vector3 touchStart;
    //public Camera cam;
    //public float groundZ = 0;

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        touchStart = GetWorldPosition(groundZ);
    //    }
    //    if (Input.GetMouseButton(0))
    //    {
    //        Vector3 direction = touchStart - GetWorldPosition(groundZ);
    //        cam.transform.position += direction;
    //    }
    //}
    //private Vector3 GetWorldPosition(float z)
    //{
    //    Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
    //    Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
    //    float distance;
    //    ground.Raycast(mousePos, out distance);
    //    return mousePos.GetPoint(distance);
    //}
}
