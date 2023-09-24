using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0F;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Move left / right
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Horizontal");
        controller.SimpleMove(forward * curSpeed);
    }
}
