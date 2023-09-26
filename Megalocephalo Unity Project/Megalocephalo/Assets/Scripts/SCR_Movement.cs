using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;
using System;

public class Movement : MonoBehaviour
{
    //private float moveSpeed = 5.0f;
    //private float jumpForce = 3.0f;
    //private float gravity = -9.81f;
    public float moveSpeed = 5.0f;
    public float jumpForce = 3.0f;
   // public float maxJumpForce = 5.0f;
    public float gravity = -9.81f;
    public float slideForce = 5f;

    private Vector3 moveDirection;

    private CharacterController characterController;

    bool isJumping;
 


    // Start is called before the first frame update
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;// * 20;
        }

        //if (characterController.isGrounded)
        //{

        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position, Vector3.down, out hit))
        //    {
        //        float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);
        //        if (slopeAngle > characterController.slopeLimit)
        //        {
        //            //Debug.DrawRay(transform.position, Vector3.down, Color.green);
        //            //// 경사면과 수평인 방향을 계산
        //            ////Vector3 slideDirection = Vector3.(hit.normal, Vector3.up);
        //            //Vector3 slideDirection = hit.normal + Vector3.up;     
        //            //// slideDirection = new Vector3(slideDirection.x, 0, 0);
        //            //moveDirection += slideDirection * slideForce;

        //            //moveDirection += gravity * Mathf.Cos(slopeAngle);



        //        }
        //    }
        //}


        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

    }

    public void MoveTo(Vector3 direction)
    {
    //    moveDirection = direction;
       
        moveDirection = new Vector3(direction.x, moveDirection.y,direction.z);

    }
    public void MoveForward(float movement)
    {

        moveDirection = new Vector3(0, moveDirection.y, 0) + gameObject.transform.forward * Math.Abs(movement);

    }
    public void JumpTo()
    {
        if(characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
            AkSoundEngine.PostEvent("TestSFX", gameObject);  // Play jump sfx here
            // isJumping = true;
        }
    }
    public void JumpStop()
    {
        if (characterController.isGrounded == false /*&& isJumping*/ && moveDirection.y > 0)
        {
            moveDirection.y = 0;
           // isJumping = false;
        }
    }



}
