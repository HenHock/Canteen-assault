//using Lean.Touch;
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

    private void Awake()
    {
        newPosition = transform.position;
    }

    private void Update()
    {
        HandleTouchInput();
    }
    private void HandleTouchInput() // ����� ������������ - ������
    {
        foreach (Touch touch in Input.touches)
        {
            if (Input.touchCount == 1) // ������� ������ ������
            {
                if (touch.phase == TouchPhase.Began) // �������� �� ����� ������ � ������� �����, ���� ���������� ���
                {
                    Plane plane = new Plane(Vector3.up, Vector3.zero);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    float entry;
                    if (plane.Raycast(ray, out entry)) // ���� ��� �������� ������, ����������� ��� �������
                    {
                        dragStartPosition = ray.GetPoint(entry);
                    }
                }
                if (touch.phase == TouchPhase.Moved) // ��������� ��������� �� ����� � ���������� ���
                {
                    Plane plane = new Plane(Vector3.up, Vector3.zero);
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    float entry;
                    if (plane.Raycast(ray, out entry)) // ���� ��� �������� ������ �������� �������� ����� �������
                    {
                        dragCurrentPosition = ray.GetPoint(entry);
                        newPosition = transform.position + dragStartPosition - dragCurrentPosition;
                    }
                }
            }
        }

        //newPosition.x = Mathf.Clamp(newPosition.x, 16f, 145f);  // ������������ ������������ ���� �� X � Z
        //newPosition.z = Mathf.Clamp(newPosition.z, -8.5f, 390f);
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime); // ������� ������������
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
