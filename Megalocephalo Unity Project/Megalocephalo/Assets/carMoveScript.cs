using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMoveScript : MonoBehaviour
{

    public float moveSpeed = 8.0f; // speed
    public float maxVelocity = 12.0f; // max speed

    public float pressJumpForce = 5; // initial jump power
    public float accelJumpForce = 1.5f; // keeping jump power
    public float maxJumpKeyPressTime = 0.5f; // max jump key pressing time

    public float additionalGravity = -2.19f; // so without additional gravity, it goes downward to slowly. I added this.


    private Rigidbody rb;
    private bool IsJumping;
    private bool IsGrounded;
    private float JumpTime;

    // to key bind settings
    public KeyCode rightMoveKey1 = KeyCode.RightArrow;
    public KeyCode rightMoveKey2 = KeyCode.D;
    public KeyCode leftMoveKey1 = KeyCode.LeftArrow;
    public KeyCode leftMoveKey2 = KeyCode.A;
    public KeyCode jumpKey = KeyCode.Space;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0);

    }

    // Update is called once per frame
    void Update()

    {
        // check is it on the ground or not
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        if (IsGrounded)
        {
           // Debug.Log("On ground");
        }
        else
        {
           // Debug.Log("Off ground");
        }

        // move forward and backward...
        if ((Input.GetKey(rightMoveKey1) || (Input.GetKey(rightMoveKey2))))
        {
            rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Acceleration);
        }
        if ((Input.GetKey(leftMoveKey1) || (Input.GetKey(leftMoveKey2))))
        {
            rb.AddForce(-Vector3.forward * moveSpeed, ForceMode.Acceleration);
        }

        // limit speed
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxVelocity)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxVelocity;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, horizontalVelocity.z);
        }

        //Debug.Log("Car speed:" + rb.velocity);

        // jump
        if (Input.GetKeyDown(jumpKey) && IsGrounded)
        {
            //Debug.Log("Car is start to jumping!!");
            rb.AddForce(Vector3.up * pressJumpForce, ForceMode.Impulse);
            IsJumping = true;
            JumpTime = 0;
        }
        // should jump more higher if you keep pressing the jump key
        if (IsJumping && Input.GetKey(jumpKey))
        {
            if (JumpTime < maxJumpKeyPressTime)
            {
                //Debug.Log("Car is still going upward!!");
                rb.AddForce(Vector3.up * accelJumpForce, ForceMode.Acceleration);
                JumpTime += Time.deltaTime;
            }
            else
            {
               // Debug.Log("Now car is start to falling!!");
                IsJumping = false;
            }
        }
        // if you do not keep press
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }

        // gravity add
        if (IsGrounded == false)
        {
           rb.AddForce(Vector3.up * additionalGravity, ForceMode.Acceleration);
        }
    }
}
