using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0F;
    public Vector3 forward;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Move left / right
        forward = Input.GetAxis("Horizontal") * transform.TransformDirection(Vector3.forward);
        controller.SimpleMove(forward * speed);
    }
}
