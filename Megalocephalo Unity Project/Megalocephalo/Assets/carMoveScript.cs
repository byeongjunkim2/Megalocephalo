using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMoveScript : MonoBehaviour
{

    public float speed = 5.0f; // Speed at which the object moves

    // Update is called once per frame
    void Update()

    {
        float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input (left or right arrow)
        float vertical = Input.GetAxis("Vertical");     // Get vertical input (up or down arrow)

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime; // Calculate movement vector

        transform.Translate(movement); // Move the object
    }
}
