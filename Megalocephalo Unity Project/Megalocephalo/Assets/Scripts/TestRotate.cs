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
            Time.timeScale = 0; // pause
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

        // transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.unscaledDeltaTime * rotationSpeed);
        // 
        if (Quaternion.Angle(currentRotation, targetRotation) < 1f)
        {
            isRotating = false;
            transform.rotation = targetRotation;  // 
            Time.timeScale = 1; // stop pause
        }
    }

    public void StartRotate(float angle)
    {
        targetRotationY += angle;
        isRotating = true;
        Time.timeScale = 0; // pause

                            // StartCoroutine(RotateCamera());
    }

    IEnumerator RotateCamera()
    {
        isRotating = true;
        Time.timeScale = 0; // pause

        float rotatedAmount = 0;
        float targetRotation = 90; // 회전하고자 하는 각도

        while (rotatedAmount < targetRotation)
        {
            float rotationThisFrame = rotationSpeed * Time.unscaledDeltaTime; // 일시정지 상태에서도 정상적으로 작동하기 위해 Time.unscaledDeltaTime을 사용합니다.
            rotatedAmount += rotationThisFrame;
            transform.Rotate(Vector3.up, rotationThisFrame);

            yield return null;
        }

        Time.timeScale = 1; // stop pause
        isRotating = false;
    }



}
