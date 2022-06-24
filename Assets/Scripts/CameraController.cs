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
    private void HandleTouchInput() // ����� ������������ - ������
    {
        foreach (Touch touch in Input.touches)
        {
            if (Input.touchCount == 1 && !UIManager.IsPointerOverUIObject() && DataManager.canMoveCamera) // ������� ������ ������
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
        
        transform.position = Vector3.Lerp(transform.position, putInBorders(newPosition), Time.deltaTime * movementTime); // ������� ������������
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
}
