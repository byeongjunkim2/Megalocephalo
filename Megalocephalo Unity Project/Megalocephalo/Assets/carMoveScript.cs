using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class carMoveScript : MonoBehaviour
{

    public float moveSpeed = 12.0f; // speed

    public float pressJumpForce = 5; // initial jump power
    public float maxJumpKeyPressTime = 0.5f; // max jump key pressing time

    public float additionalGravity = -2.19f; // so without additional gravity, it goes downward to slowly. I added this.


    private Rigidbody rb;
    private bool IsJumping;
    private bool IsGrounded;
    private bool IsWallRightSide;
    private bool IsWallLeftSide;
    private float JumpTime;

    // to key bind settings
    public KeyCode rightMoveKey1 = KeyCode.RightArrow;
    public KeyCode rightMoveKey2 = KeyCode.D;
    public KeyCode leftMoveKey1 = KeyCode.LeftArrow;
    public KeyCode leftMoveKey2 = KeyCode.A;
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode shootKey = KeyCode.F;

    private void Start()
    {   
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0);

    }

    // Update is called once per frame
    void Update()

    {
        // to easy copy and paste...              rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);

        // check is it on the ground or not
        IsGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        IsWallRightSide = Physics.Raycast(transform.position, Vector3.right, 1.2f);
        IsWallLeftSide = Physics.Raycast(transform.position, Vector3.left, 1.2f);
        if (IsGrounded)
        {
           // Debug.Log("On ground");
        }
        else
        {
            // Debug.Log("Off ground");
        }

        // if stucked in wall
        if (IsWallRightSide == true)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if (IsWallLeftSide == true)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }

        // shoot?
        if ((Input.GetKey(shootKey))){
            
        }

        // move forward and backward...
        if ((Input.GetKey(rightMoveKey1) || (Input.GetKey(rightMoveKey2))) && IsWallRightSide == false)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveSpeed);
        }
        else if ((Input.GetKey(leftMoveKey1) || (Input.GetKey(leftMoveKey2))) && IsWallLeftSide == false)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -moveSpeed);
        }

        // todo more modify (for case: right move and release left key...)
        if ((Input.GetKeyUp(rightMoveKey1) || (Input.GetKeyUp(rightMoveKey2))))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        }
        else if ((Input.GetKeyUp(leftMoveKey1) || (Input.GetKeyUp(leftMoveKey2))))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
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
            // if he release the jump button during jump
            if (IsJumping == true)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            }
            IsJumping = false;
        }

        // gravity add
        if (IsGrounded == false)
        {
           rb.AddForce(Vector3.up * additionalGravity, ForceMode.Acceleration);
        }      
    }
}
