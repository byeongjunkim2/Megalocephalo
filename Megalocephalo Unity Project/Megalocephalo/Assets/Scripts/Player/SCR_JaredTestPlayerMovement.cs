using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_JaredTestPlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float orientation; // in degrees
    public bool facingRight;
    public bool onGround;

    public float walkSpeed;
    public float gravityAcceleration;
    public Vector2 moveVector;

    public float initRotationOffset; // in degrees
    public float facingRotationOffset; // in degrees
    private float currentRotationOffset;
    public float rotationLerpAmount;


    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody>();

        moveVector = Vector2.zero;

        currentRotationOffset = initRotationOffset + facing() * facingRotationOffset;
    }

    // Update is called once per frame
    void Update()
    {

        moveVector = new Vector2(0.0f, moveVector.y);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {

            if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight) facingRight = true;
            if (Input.GetAxisRaw("Horizontal") < 0 && facingRight) facingRight = false;
            moveVector += new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed, 0.0f);

        }

        if (!onGround)
        {
            moveVector -= new Vector2(0.0f, gravityAcceleration);
        }

        Vector3 orientationVector = new Vector3(Mathf.Cos(orientation * Mathf.Deg2Rad), 0.0f, Mathf.Sin(orientation * Mathf.Deg2Rad)).normalized;
        Vector3 movementVector = new Vector3(moveVector.x, moveVector.y, 0.0f);
        rb.velocity = Vector3.RotateTowards(movementVector, orientationVector * facing(), orientation * Mathf.Deg2Rad, 0.0f);

        currentRotationOffset = Mathf.Lerp(currentRotationOffset, initRotationOffset + facing() * facingRotationOffset + orientation, rotationLerpAmount);
        Vector3 rotationVector = new Vector3(0.0f, currentRotationOffset, 0.0f);
        transform.rotation = Quaternion.Euler(rotationVector);

    }

    private void OnDrawGizmos()
    {
        Vector3 rotateVector = new Vector3(Mathf.Cos(orientation * Mathf.Deg2Rad), 0.0f, Mathf.Sin(orientation * Mathf.Deg2Rad));
        Ray ray = new Ray(transform.position, rotateVector);
        Gizmos.DrawRay(ray);
    }

    int facing()
    {
        return (facingRight) ? 1 : -1;
    }

}
