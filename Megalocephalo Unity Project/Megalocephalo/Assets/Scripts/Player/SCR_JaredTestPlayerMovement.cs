using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

// code by jared 

public class SCR_JaredTestPlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public bool facingRight; // whether or not the player is facing right; does not mean visibly
    public bool onGround; // whether or not the player is on the ground

    public float walkSpeed; // how fast the player walks
    public float gravityAcceleration; // how fast the player's y velocity increases as they fall
    public Vector2 moveVector; // the vector used for movement, later rotated by the orientation

    public float orientation; // what angle the player moves in, in degrees
    public float orientationSpeed; // how fast the angle changes as you walk, for circular movement

    public float initRotationOffset; // initial offset of player, in degrees
    public float facingRotationOffset; // how much the player rotates based on the facing direction, in degrees
    private float currentRotationOffset; // used for interpolation
    public float rotationLerpAmount; // how quickly the rotation interpolates


    // Start is called before the first frame update
    void Start()
    {
        // get ridigbody from object
        rb = GetComponent<Rigidbody>();

        // set player speed to zero
        moveVector = Vector2.zero;

        // set rotation offset
        currentRotationOffset = initRotationOffset - facing() * facingRotationOffset;
    }

    // Update is called once per frame
    void Update()
    {

        // cancel horizontal movement; will likely have to change later
        moveVector = new Vector2(0.0f, moveVector.y);

        // check if the player pressed left or right
        if (Input.GetAxisRaw("Horizontal") != 0)
        {

            // update facing
            if (Input.GetAxisRaw("Horizontal") > 0 && !facingRight) facingRight = true;
            if (Input.GetAxisRaw("Horizontal") < 0 && facingRight) facingRight = false;

            // set horizontal velocity
            moveVector += new Vector2(Input.GetAxisRaw("Horizontal") * walkSpeed, 0.0f);
            orientation += Input.GetAxisRaw("Horizontal") * orientationSpeed * walkSpeed * Time.deltaTime;
            orientation = (orientation + 360.0f) % 360.0f;

        }

        // jumping and gravity currently doesn't work; just checking this for later
        if (!onGround)
        {
            moveVector -= new Vector2(0.0f, gravityAcceleration);
        }

        // rotate movement vector
        Vector3 orientationVector = new Vector3(Mathf.Cos(-orientation * Mathf.Deg2Rad), 0.0f, Mathf.Sin(-orientation * Mathf.Deg2Rad)).normalized;
        Vector3 movementVector = new Vector3(moveVector.x, moveVector.y, 0.0f);
        rb.velocity = Vector3.RotateTowards(movementVector, orientationVector * facing(), orientation * Mathf.Deg2Rad, 0.0f);

        // rotate player (visually)
        currentRotationOffset = Mathf.Lerp(currentRotationOffset, initRotationOffset - facing() * facingRotationOffset, rotationLerpAmount);
        Vector3 rotationVector = new Vector3(0.0f, currentRotationOffset + orientation, 0.0f);
        transform.rotation = Quaternion.Euler(rotationVector);

    }

    // return what direction the player is facing (1 for right, -1 for left)
    int facing()
    {
        return (facingRight) ? 1 : -1;
    }

}
