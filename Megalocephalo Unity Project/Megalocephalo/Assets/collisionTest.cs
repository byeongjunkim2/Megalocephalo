using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionTest : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            if (isCollided == false)
            {
                Debug.Log("Bullet collided: " + count++);
            }
            isCollided = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            isCollided = false;
        }
    }

    public float moveSpeed = 50; // speed
    private Rigidbody rb;
    Vector3 movement;
    bool isDirectionLeft = false;
    int count = 0;
    bool isCollided = false;


    private void Start()
    {
        movement = new Vector3(0, 0, moveSpeed);
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > 125)
        {
            isDirectionLeft = false;
        }
        else if (transform.position.z < 0)
        {
            isDirectionLeft = true;
        }

        if (isDirectionLeft == true)
        {
            transform.Translate(movement * Time.deltaTime);
        }
        else
        {
            transform.Translate(-movement * Time.deltaTime);
        }


    }
}