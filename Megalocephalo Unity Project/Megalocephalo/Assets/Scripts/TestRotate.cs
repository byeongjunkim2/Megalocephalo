using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class TestRotate : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public float targetRotationY = 0f;
    private bool isRotating = false;

    private KeyCode testKeyCode = KeyCode.C;

    // Start is called before the first frame update
    void Awake()
    {
        targetRotationY = transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(testKeyCode) && !isRotating)
        {
            targetRotationY -= 90f;
            isRotating = true;
        }

        if (isRotating)
        {
            RotateObject();
        }


    }

    void RotateObject()
    {
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, targetRotationY, 0);

        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);

        // 회전이 목표 각도에 근접하면 회전 중지
        if (Quaternion.Angle(currentRotation, targetRotation) < 1f)
        {
            isRotating = false;
            transform.rotation = targetRotation;  // 정확한 각도로 설정
        }
    }




}
